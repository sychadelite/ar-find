using System.Collections;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class VoucherScript : MonoBehaviour
{
  public GameObject voucherCard;
  public GameObject voucherTitle;
  public GameObject voucherDuration;
  public GameObject voucherCompany;
  private GameObject ObjectSpawn;
  public GameObject content;
  public GameObject loading;

  private readonly string API_KEY = "mcI3MrU4F0sAvs+9Pg4R1DSWHR8CgO0DdlhXso2lepw=";

  void Start()
  {
    PlayerPrefs.DeleteKey("selected_voucher");
    loading.SetActive(true);
    StartCoroutine(GetUserVoucher_Coroutine());
  }

  IEnumerator GetUserVoucher_Coroutine()
  {
    string url = $"https://find-ar-app.com/api/transactions/key/{API_KEY}/user/{PlayerPrefs.GetString("user_id")}";
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

        bool isEmpty = response["result"].Count == 0;
        GameObject.Find("EmptyPlaceholder").SetActive(isEmpty);

        for (int i = 0; i < response["result"].Count; i++)
        {
          // Spawn voucher object
          GameObject voucherSpawn = InstantiateObject(voucherCard);
          voucherSpawn.gameObject.SetActive(true);
          voucherSpawn.transform.localScale = new Vector3(1f, 1f, 1f);

          int voucherId = response["result"][i]["id"];
          string voucherTitleStr = response["result"][i]["name"];
          string resultVoucher = voucherTitleStr.Length > 38 ? voucherTitleStr.Substring(0, 38) + "..." : voucherTitleStr;
          string company = response["result"][i]["company"];
          string resultCompany = company.Length > 25 ? company.Substring(0, 25) + "..." : company;
          string dateResult = response["result"][i]["created_at"];
          string date = dateResult.Split('T')[0];

          // Spawn title text
          var titleObj = Instantiate(voucherTitle);
          titleObj.transform.SetParent(voucherSpawn.transform);
          titleObj.transform.localPosition = new Vector3(0, 25f, 0);
          titleObj.transform.localScale = new Vector3(1f, 1f, 1f);
          titleObj.GetComponent<Text>().text = resultVoucher;

          // Spawn company text
          var companyObj = Instantiate(voucherCompany);
          companyObj.transform.SetParent(voucherSpawn.transform);
          companyObj.transform.localPosition = new Vector3(0f, 35f, 0f);
          companyObj.transform.localScale = new Vector3(1f, 1f, 0);
          companyObj.GetComponent<Text>().text = resultCompany;

          // Spawn date text
          TimeSpan deltaDate = FormatDate(date).AddDays(7).Subtract(DateTime.Now);
          string resultDate = deltaDate.Days.Equals(0) ? "Hari ini" : $"{deltaDate.Days + 1} hari lagi";
          if (deltaDate.Days < 0)
          {
            StartCoroutine(DeleteVoucher_Coroutine(response["result"][i]["id"]));
            Debug.Log("Delete : " + response["result"][i]["id"]);
          }
          else
          {
            var durationObj = Instantiate(voucherDuration);
            durationObj.transform.SetParent(voucherSpawn.transform);
            durationObj.transform.localScale = new Vector3(1f, 1f, 0);
            durationObj.transform.localPosition = new Vector3(40f,-45f,0);
            durationObj.GetComponent<Text>().text = resultDate;
            voucherSpawn.GetComponent<Button>().onClick.AddListener(() => CardOnClick(voucherId, FormatDate(date).AddDays(7)));
          }
        }

        if (request.result.Equals(UnityWebRequest.Result.Success) && request.isDone)
        {
          loading.SetActive(false);
        }

      }
    }
  }



  private GameObject InstantiateObject(GameObject obj)
  {
    ObjectSpawn = Instantiate(obj, transform.position, Quaternion.identity);
    float width = ObjectSpawn.GetComponent<RectTransform>().sizeDelta.x;
    ObjectSpawn.GetComponent<RectTransform>().sizeDelta = new Vector2(width , 135);
    ObjectSpawn.transform.SetParent(content.transform);
    return ObjectSpawn;
  }

  public void CardOnClick(int id, DateTime duration)
  {
    PlayerPrefs.SetInt("selected_voucher", id);
    string month = FormatDateString.FormatDate(duration.Month);
    PlayerPrefs.SetString("selected_voucher_duration", $"{duration.Day} {month} {duration.Year}");
    SceneManager.LoadScene(9);
  }

  private DateTime FormatDate(string date)
  {
    string[] dateDestruct = date.Split('-');
    int years = int.Parse(dateDestruct[0]);
    int month = dateDestruct[1].Substring(0, 1).Equals("0") ? int.Parse(dateDestruct[1].Substring(1, dateDestruct[1].Length - 1)) : int.Parse(dateDestruct[1]);
    int days = dateDestruct[2].Substring(0, 1).Equals("0") ? int.Parse(dateDestruct[2].Substring(1, dateDestruct[2].Length - 1)) : int.Parse(dateDestruct[2]);
    DateTime dateTime = new DateTime(years, month, days);
    return dateTime;
  }

  IEnumerator DeleteVoucher_Coroutine(int id)
  {
    string url = $"https://find-ar-app.com/api/transactions/delete/{id}/key/{API_KEY}";
    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
      yield return request.SendWebRequest();
      if (request.error != null)
      {
        Debug.Log(request.error);
      }
      else
      {
        if (request.isDone && request.result.Equals(UnityWebRequest.Result.Success))
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
      }
    }
  }
}

