using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
 
public class SendLobbyDataAvenue2 : MonoBehaviour {

    private readonly string API_KEY = "mcI3MrU4F0sAvs+9Pg4R1DSWHR8CgO0DdlhXso2lepw=";

    public void StartSendDataAvenue2() {
        StartCoroutine(Upload());
    }
     
    IEnumerator Upload() {

        string userId = PlayerPrefs.GetString("user_id");
        string url = $"https://find-ar-app.com/api/visitor";

        WWWForm form = new WWWForm();
        form.AddField("key", API_KEY);
        form.AddField("user_id", userId);
        form.AddField("place", "l_avenue2");
     
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();
     
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
        }
    }
}