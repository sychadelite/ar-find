using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class TimerTap : MonoBehaviour
{
    public float timeRemaining;
    public Text timeText;
    bool move = true;
    //public RectTransform transformText;
    bool isUpload = true;


    void Start()
    {
        timeRemaining = 30;
    }

    void Update()
    {
        int timeDisplay = (int)timeRemaining;
        timeText.text = timeDisplay.ToString();

        //if (timeRemaining < 10 && move == true)
        //{
        //transformText.transform.position = new Vector3(transformText.transform.position.x + (float)0.1, transformText.transform.position.y, transformText.transform.position.z);
        //move = false;
        //}

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            TimeMaster.instance.SaveDate();
            timeRemaining = 0;
            if (isUpload)
            {
                StartCoroutine(Upload());
                isUpload = false;
            }
            SceneManager.LoadScene("ScanAR");
        }
    }

    IEnumerator Upload()
    {
        int coinBefore = PlayerPrefs.GetInt("coins");
        int coinGame = PlayerPrefs.GetInt("coinGame");
        PlayerPrefs.SetInt("coinGame", 0);
        PlayerPrefs.SetInt("coins", coinBefore + coinGame);
        WWWForm form = new WWWForm();
        //form.AddField("id", "111934081164762");
        form.AddField("id", PlayerPrefs.GetString("user_id"));
        form.AddField("key", "mcI3MrU4F0sAvs+9Pg4R1DSWHR8CgO0DdlhXso2lepw=");
        form.AddField("coins", PlayerPrefs.GetInt("coins"));

        using (UnityWebRequest www = UnityWebRequest.Post("https://find-ar-app.com/api/users/update", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }

    }

}
