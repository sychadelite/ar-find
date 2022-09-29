using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UsersController : MonoBehaviour
{
  public Text TextUserName;
  public Text TotalScore;
  public GameObject loadingScreen;

  private readonly string API_KEY = "mcI3MrU4F0sAvs+9Pg4R1DSWHR8CgO0DdlhXso2lepw=";

  private struct User
  {
    public string first_name;
    public string last_name;
    public string coins;
  }

  void Awake()
  {
    loadingScreen.SetActive(true);
  }

  void Start()
  {
    StartCoroutine(GetUser());
  }

  public void Reload()
  {
    Scene scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(scene.buildIndex);
  }

  IEnumerator GetUser()
  {
    string userId = PlayerPrefs.GetString("user_id");
    string url = $"https://find-ar-app.com/api/users/{userId}/key/{API_KEY}";

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
          if (request.error.Contains("404"))
          {
            SceneManager.LoadScene(0);
          }
        }
        else
        {
          User user = JsonUtility.FromJson<User>(request.downloadHandler.text);
          PlayerPrefs.SetString("first_name", user.first_name);
          PlayerPrefs.SetString("last_name", user.last_name);
          PlayerPrefs.SetInt("coins", int.Parse(user.coins));
          TextUserName.text = $"Hi, {PlayerPrefs.GetString("first_name")} {PlayerPrefs.GetString("last_name")}";
          TotalScore.text = PlayerPrefs.GetInt("coins").ToString();
          loadingScreen.SetActive(false);
        }
      }
    }
  }
}

