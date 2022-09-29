using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FacebookController : MonoBehaviour
{
  private readonly string API_KEY = "mcI3MrU4F0sAvs+9Pg4R1DSWHR8CgO0DdlhXso2lepw=";
  public Image loadingScreen;

  private struct User
  {
    public string id;
    public string first_name;
    public string last_name;
    public string coins;
  }

  private void LoggedinCompleted()
  {
    if (!string.IsNullOrEmpty(PlayerPrefs.GetString("access_token")))
    {
      SceneManager.LoadScene(2);
      return;
    }
  }

  private void Awake()
  {
    if (!FB.IsInitialized)
    {
      FB.Init(SetInit, OnHidenUnity);
    }
    else
      FB.ActivateApp();
  }

  void SetInit()
  {
    if (FB.IsInitialized)
    {
      LoggedinCompleted();
      FB.ActivateApp();
    }
    else
    {
      Debug.LogError("Error initialize");
      loadingScreen.gameObject.SetActive(false);
    }
  }

  void OnHidenUnity(bool isGameShown)
  {
    if (!isGameShown)
      Time.timeScale = 0;
    else
      Time.timeScale = 1;
  }

  public void FBLogin()
  {
    loadingScreen.gameObject.SetActive(true);
    List<string> permissions = new List<string>
    {
      "public_profile",
    };
    FB.LogInWithReadPermissions(permissions, AuthCallBack);
  }

  IEnumerator GetUserData(string userId)
  {
    string url = $"https://find-ar-app.com/api/users/{userId}/key/{API_KEY}";
    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
      yield return request.SendWebRequest();

      if (request.error != null)
        Debug.Log(request.error);
      else
      {
        if (!string.IsNullOrEmpty(request.downloadHandler.text))
        {
          User response = JsonUtility.FromJson<User>(request.downloadHandler.text);
          PlayerPrefs.SetString("user_id", response.id);
          PlayerPrefs.SetString("first_name", response.first_name);
          PlayerPrefs.SetString("last_name", response.last_name);
          PlayerPrefs.SetInt("coins", int.Parse(response.coins));
          Debug.Log("Data found : " + request.downloadHandler.text);
          LoggedinCompleted();
          yield break;
        }
        else
        {
          Debug.Log("Data not found");
          Debug.Log("Create a new account...");
        }
      }
    }
  }

  void AuthCallBack(IResult result)
  {
    if (result.Error != null)
    {
      Debug.Log(result.Error);
      loadingScreen.gameObject.SetActive(false);
    }
    else
      if (FB.IsLoggedIn)
    {
      PlayerPrefs.SetString("access_token", result.ResultDictionary["access_token"].ToString());
      string userId = result.ResultDictionary["user_id"].ToString();
      StartCoroutine(GetUserData(userId));

      FB.API($"/{userId}?fields=first_name,last_name", HttpMethod.GET, SaveData);
      Debug.Log("Facebook is Login!");
    }
    else
    {
      Debug.Log("Facebook is not Logged in!");
      loadingScreen.gameObject.SetActive(false);
    }
  }

  void SaveData(IResult result)
  {
    if (result.Error != null)
    {
      Debug.Log(result.Error);
    }
    else
    {
      StartCoroutine(SaveUserData(result));
      Debug.Log("Data saving... " + result);
    }
  }

  IEnumerator SaveUserData(IResult result)
  {
    string url = "https://find-ar-app.com/api/users";
    string id = result.ResultDictionary["id"].ToString();
    string firstName = result.ResultDictionary["first_name"].ToString();
    string lastName = result.ResultDictionary["last_name"].ToString();

    WWWForm form = new WWWForm();
    form.AddField("key", API_KEY);
    form.AddField("id", id);
    form.AddField("first_name", firstName);
    form.AddField("last_name", lastName);

    using (UnityWebRequest request = UnityWebRequest.Post(url, form))
    {
      yield return request.SendWebRequest();

      if (result.Error != null)
      {
        loadingScreen.gameObject.SetActive(false);
        Debug.Log(result.Error);
      }
      else
      {
        PlayerPrefs.SetString("user_id", id);
        PlayerPrefs.SetString("first_name", firstName);
        PlayerPrefs.SetString("last_name", lastName);
        PlayerPrefs.SetInt("coins", 0);
        Debug.Log(request.downloadHandler.text);
        LoggedinCompleted();
      }
    }
  }
}