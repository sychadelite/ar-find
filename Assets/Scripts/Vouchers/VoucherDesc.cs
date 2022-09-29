using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class VoucherDesc : MonoBehaviour
{
  public Text voucherDesc;
  public GameObject successScene;
  public Text voucherDate;
  public Text voucherCompany;
  public Text voucherTitle;

  private readonly string API_KEY = "mcI3MrU4F0sAvs+9Pg4R1DSWHR8CgO0DdlhXso2lepw=";
  void Start()
  {
    if (PlayerPrefs.GetInt("selected_voucher").Equals(0))
    {
      SceneManager.LoadScene(6);
    }
    StartCoroutine(GetVoucherDesc_Coroutine());
  }

  // Tampilkan voucher sesuai dengan Id
  IEnumerator GetVoucherDesc_Coroutine()
  {
    string url = $"https://find-ar-app.com/api/transactions/{PlayerPrefs.GetInt("selected_voucher")}/key/{API_KEY}";
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
          JSONNode json = JSON.Parse(request.downloadHandler.text);
          JSONNode response = json[0];

          string desc = response["description"];
          string company = response["company"];
          string title = response["name"];
          string duration = PlayerPrefs.GetString("selected_voucher_duration");

          voucherDesc.text = desc;
          voucherCompany.text = company;
          voucherDate.text = duration;
          voucherTitle.text = title;
        }
      }
    }
  }

  // Gunakan voucher
  public void UsingVoucher()
  {
    StartCoroutine(UseVoucher_Coroutine());
  }

  IEnumerator UseVoucher_Coroutine()
  {
    string url = $"https://find-ar-app.com/api/transactions/delete/{PlayerPrefs.GetInt("selected_voucher")}/key/{API_KEY}";
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
          successScene.SetActive(true);
        }
      }
    }
  }
}
