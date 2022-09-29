using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public bool answer;
    public GameObject lanjut;
    public Button[] choiceButtons;
    public Quiz quiz;
    //public GameObject plane;

    void Start()
    {
        PlayerPrefs.SetInt("coinGame", 0);
    }

    public void CheckAnswer()
    {
        if (answer)
        {
            Debug.Log("benar");
            int coinBefore = PlayerPrefs.GetInt("coinGame");
            PlayerPrefs.SetInt("coinGame", coinBefore + 10);
            quiz.benar = quiz.benar + 1;
            lanjut.SetActive(true);
        }
        else
        {
            Debug.Log("salah");
            lanjut.SetActive(true);
        }
        foreach (Button choiceButton in choiceButtons)
        {
            choiceButton.interactable = false;
        }
        //GameObject item = Instantiate(plane,
          //      new Vector3(337, 558, -312),
            //    plane.transform.rotation) as GameObject;
    }
}
