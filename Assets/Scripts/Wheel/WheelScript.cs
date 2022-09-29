using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;

public class WheelScript : MonoBehaviour
{
  public GameObject button;
  public Text TotalScore;
  public GameObject loading;
  public GameObject popup;
  public GameObject reward;

  private readonly string API_KEY = "mcI3MrU4F0sAvs+9Pg4R1DSWHR8CgO0DdlhXso2lepw=";
  private float speed = 0f;
  private bool isClicked = false;
  private Button btnSpin;

  private struct Response
  {
    public string result;
  }

  void Start()
  {
    btnSpin = button.GetComponent<Button>();

    btnSpin.onClick.AddListener(() =>
    {
      int currentCoins = PlayerPrefs.GetInt("coins");
      if (!isClicked && (PlayerPrefs.GetInt("coins") >= 100))
      {
        PlayerPrefs.SetInt("coins", currentCoins - 100);
        isClicked = true;
        // Update user coins (-100) 
        StartCoroutine(UserPutData_Coroutine(currentCoins - 100));

        // Start spin
        this.speed = Random.Range(500, 1000);
      }
      else
      {
        // Coins not enough
        loading.SetActive(true);
        popup.SetActive(true);
      }
    });
  }

  // Spinning actions
  void Update()
  {
    if (isClicked)
    {
      switch (Mathf.Ceil(this.speed))
      {
        case 1:
          this.speed = 0;
          break;

        case 0:
          int finalAngel = Mathf.RoundToInt(transform.eulerAngles.z);
          isClicked = false;
          Debug.Log(DisplayResult(finalAngel));
          break;

        default:
          this.speed *= 0.96f;
          break;
      }
    }
    this.transform.Rotate(0, 0, this.speed);
  }

  void DisplayCoins(int coins)
  {
    PlayerPrefs.SetString("voucher_type", "Coins");
    PlayerPrefs.SetString("voucher_name", $"Selamat! Anda Mendapatkan {coins.ToString()} Koin!");
    StartCoroutine(UserPutData_Coroutine(PlayerPrefs.GetInt("coins") + coins));
    reward.SetActive(true);
  }

  // Result Actions
  private string DisplayResult(int angel)
  {
    int additonalCoins = Random.Range(1, 101);

    if ((angel >= 0 && angel < 45) || (angel >= 90 && angel < 135) || angel >= 180 && angel < 225 || angel >= 270 && angel < 315)
    {
      StartCoroutine(GetVoucher_Coroutine());
      return "Voucher discount makanan";
    }
    else if ((angel >= 45 && angel < 90) || (angel >= 135 && angel < 180) || (angel >= 225 && angel < 270) || (angel >= 315 && angel < 360))
    {
      DisplayCoins(additonalCoins);
      return $"{additonalCoins} Coins";
    }
    else
    {
      StartCoroutine(UserPutData_Coroutine(PlayerPrefs.GetInt("coins") + additonalCoins));
      return $"{additonalCoins} Coins";
    }
  }

  // Update user coins
  IEnumerator UserPutData_Coroutine(int updatedCoins)
  {
    loading.SetActive(true);
    string url = "https://find-ar-app.com/api/users/update";
    string id = PlayerPrefs.GetString("user_id");
    int coins = updatedCoins;

    WWWForm form = new WWWForm();
    form.AddField("key", API_KEY);
    form.AddField("id", id);
    form.AddField("coins", coins);

    using (UnityWebRequest request = UnityWebRequest.Post(url, form))
    {
      yield return request.SendWebRequest();
      if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
      {
        Debug.Log(request.error);
      }
      else
      {
        Response res = JsonUtility.FromJson<Response>(request.downloadHandler.text);
        StartCoroutine(GetUser());
      }
    }
  }

  // Get user data
  IEnumerator GetUser()
  {
    string id = PlayerPrefs.GetString("user_id");
    string url = $"https://find-ar-app.com/api/users/{id}/key/{API_KEY}";
    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
      yield return request.SendWebRequest();

      if (string.IsNullOrEmpty(request.downloadHandler.text))
      {
        SceneManager.LoadScene(0);
      }
      else
      {
        if (request.error != null)
        {
          Debug.Log(request.error);
        }
        else
        {
          User user = JsonUtility.FromJson<User>(request.downloadHandler.text);
          PlayerPrefs.SetString("first_name", user.first_name);
          PlayerPrefs.SetString("last_name", user.last_name);
          PlayerPrefs.SetInt("coins", int.Parse(user.coins));
          TotalScore.text = user.coins;

          if (request.result.Equals(UnityWebRequest.Result.Success))
          {
            Debug.Log("Success");
            loading.SetActive(false);
          }
        }
      }
    }
  }

  // Get voucher data
  IEnumerator GetVoucher_Coroutine()
  {
    loading.SetActive(true);
    string url = $"https://find-ar-app.com/api/vouchers/key/{API_KEY}";
    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
      yield return request.SendWebRequest();

      if (request.error != null)
      {
        Debug.Log(request.error);
      }
      else
      {
        string newJson = "{\"result\":" + request.downloadHandler.text + "}";
        var response = JSON.Parse(newJson);
        int randomIndex = Random.Range(0, response["result"].Count);
        JSONNode selectedVoucher = response["result"][randomIndex];

        while (!request.isDone)
        {
          Debug.Log(request.result);
        }

        if (request.isDone)
        {
          StartCoroutine(SaveVoucher_Coroutine(PlayerPrefs.GetString("user_id"), selectedVoucher["id"].ToString()));
          PlayerPrefs.SetString("voucher_type", selectedVoucher["type"]);
          PlayerPrefs.SetString("voucher_name", selectedVoucher["name"]);
          PlayerPrefs.SetString("voucher_desc", selectedVoucher["description"]);
          PlayerPrefs.SetString("voucher_company", selectedVoucher["company"]);

          Debug.Log(PlayerPrefs.GetString("voucher_name"));

          loading.SetActive(false);

          reward.SetActive(true);
        }
      }
    }
  }

  // Save voucher to database
  IEnumerator SaveVoucher_Coroutine(string userId, string voucherId)
  {
    loading.SetActive(true);

    string url = "https://find-ar-app.com/api/transactions";

    WWWForm form = new WWWForm();
    form.AddField("key", API_KEY);
    form.AddField("user_id", userId);
    form.AddField("voucher_id", int.Parse(voucherId));

    using (UnityWebRequest request = UnityWebRequest.Post(url, form))
    {
      request.SetRequestHeader("Accept", "application/json");

      yield return request.SendWebRequest();

      if (request.error != null)
      {
        Debug.Log(request.error);
      }

      if (request.isDone)
      {
        Debug.Log("User ID : " + userId + " Voucher ID : " + voucherId);
        loading.SetActive(false);
      }
    }
  }
}
