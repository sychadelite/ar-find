using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserGame : MonoBehaviour
{

  private readonly string API_KEY = "mcI3MrU4F0sAvs+9Pg4R1DSWHR8CgO0DdlhXso2lepw=";

  private struct User
  {
    public string first_name;
    public string last_name;
    public string coins;
  }

  void Start()
  {

    StartCoroutine(GetUser());
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
        }
      }
    }
  }
}

