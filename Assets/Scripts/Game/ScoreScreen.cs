using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
    public Quiz quiz;
    public Text perfectJumlahBenar;
    public GameObject perfecttext;
    public Text goodJumlahBenar;
    public GameObject goodtext;
    public Text badJumlahBenar;
    public GameObject badtext;
    public Text score;
    public GameObject scoreScreen;

    // Start is called before the first frame update
    public void perfect()
    {
        scoreScreen.SetActive(true);
        perfecttext.SetActive(true);
    }

    public void good()
    {
        scoreScreen.SetActive(true);
        goodtext.SetActive(true);
    }

    public void bad()
    {
        scoreScreen.SetActive(true);
        badtext.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = (quiz.benar * 10).ToString();
        perfectJumlahBenar.text = quiz.benar.ToString();
        goodJumlahBenar.text = quiz.benar.ToString();
        badJumlahBenar.text = quiz.benar.ToString();
    }

    public void changeMode()
    {
        if (quiz.benar >= 10)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            SceneManager.LoadScene("HintScene");
        }
    }
}
