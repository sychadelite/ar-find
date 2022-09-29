using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizResume : MonoBehaviour
{
    public Quiz quiz;
    public Button[] choiceButtons;
    public void Resume()
    {
        Destroy(GameObject.FindWithTag("question"));
        foreach (Button choiceButton in choiceButtons)
        {
            choiceButton.interactable = true;
        }
        quiz.QuizStart();
        this.gameObject.SetActive(false);
    }

}
