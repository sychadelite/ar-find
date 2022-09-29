using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTimer : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject PlayTimerButton;
    
    public float timeRemaining;
    public Text timeText;

    void Start()
    {
        timeRemaining = 305;
        if(!PlayerPrefs.HasKey("firsttime")){
            PlayerPrefs.SetString("firsttime", "yes");
            timeRemaining = 0;
        }
        timeRemaining -= TimeMaster.instance.CheckDate();
    }

    void Update()
    {
        Debug.Log(PlayerPrefs.GetString("savedTime"));
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            PlayButton.SetActive(true);
            PlayTimerButton.SetActive(false);
        }
    }

    public void ResetTimer()
    {
        TimeMaster.instance.SaveDate();
    }
}
