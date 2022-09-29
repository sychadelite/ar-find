using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateScore : MonoBehaviour
{
  private readonly string API_KEY = "mcI3MrU4F0sAvs+9Pg4R1DSWHR8CgO0DdlhXso2lepw=";
  private readonly string url = "https://find-ar-app.com/api/users/update";

  private struct Response
  {
    public string result;
  }

  void Start()
  {
    StartCoroutine(UserPutData_Coroutine(100));
  }

  IEnumerator UserPutData_Coroutine(int currentCoins)
  {
    string id = PlayerPrefs.GetString("user_id");
    int coins = currentCoins;

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
        Debug.Log(res.result);
      }
    }
  }
}
