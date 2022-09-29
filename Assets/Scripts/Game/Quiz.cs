using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public string[] questions;
    public Text questionGameobject;
    public GameObject[] prefabQuiz;
    public GameObject[] prefabQuiz1;
    public GameObject[] prefabQuiz2;
    public Text[] choicesPanel;
    public string[] choices;
    public string[] choices1;
    public string[] choices2;
    public Answer[] answers;
    public int benar;



    public void QuizStart()
    {
        //Destroy(GameObject.FindWithTag("question"));
        int randomquest = Random.Range(0, questions.Length);
        questionGameobject.text = questions[randomquest];
        if (randomquest == 0)
        {
            int randomQueston = Random.Range(0, prefabQuiz.Length);
            int randomPanel = Random.Range(0, choicesPanel.Length);
            answers[randomPanel].answer = true;
            int randomAnotherQuestion1 = 0;
            int randomAnotherQuestion2 = 0;
            int randomAnotherQuestion3 = 0;

            choicesPanel[randomPanel].text = choices[randomQueston];
            GameObject item = Instantiate(prefabQuiz[randomQueston],
                    new Vector3(200, 780, -400),
                    prefabQuiz[randomQueston].transform.rotation) as GameObject;

            int j = 0;
            for (int i = 0; i <= 3; i++)
            {
                if (i != randomPanel)
                {
                    answers[i].answer = false;
                    j++;
                    if (j == 1)
                    {
                        do
                        {
                            randomAnotherQuestion1 = Random.Range(0, prefabQuiz.Length);
                            choicesPanel[i].text = choices[randomAnotherQuestion1];
                        } while (randomAnotherQuestion1 == randomQueston);
                    }
                    else if (j == 2)
                    {
                        do
                        {
                            randomAnotherQuestion2 = Random.Range(0, prefabQuiz.Length);
                            choicesPanel[i].text = choices[randomAnotherQuestion2];
                        } while (randomAnotherQuestion2 == randomAnotherQuestion1 || randomAnotherQuestion2 == randomQueston);
                    }
                    else if (j == 3)
                    {
                        do
                        {
                            randomAnotherQuestion3 = Random.Range(0, prefabQuiz.Length);
                            choicesPanel[i].text = choices[randomAnotherQuestion3];
                        } while (randomAnotherQuestion3 == randomQueston || randomAnotherQuestion3 == randomAnotherQuestion1 || randomAnotherQuestion3 == randomAnotherQuestion2);
                    }
                }
            }
        }
        else if (randomquest == 1)
        {
            int randomQueston = Random.Range(0, prefabQuiz1.Length);
            int randomPanel = Random.Range(0, choicesPanel.Length);
            answers[randomPanel].answer = true;
            int randomAnotherQuestion1 = 0;
            int randomAnotherQuestion2 = 0;
            int randomAnotherQuestion3 = 0;

            choicesPanel[randomPanel].text = choices1[randomQueston];
            GameObject item = Instantiate(prefabQuiz1[randomQueston],
                    new Vector3(200, 780, -400),
                    prefabQuiz1[randomQueston].transform.rotation) as GameObject;

            int j = 0;
            for (int i = 0; i <= 3; i++)
            {
                if (i != randomPanel)
                {
                    answers[i].answer = false;
                    j++;
                    if (j == 1)
                    {
                        do
                        {
                            randomAnotherQuestion1 = Random.Range(0, prefabQuiz1.Length);
                            choicesPanel[i].text = choices1[randomAnotherQuestion1];
                        } while (randomAnotherQuestion1 == randomQueston);
                    }
                    else if (j == 2)
                    {
                        do
                        {
                            randomAnotherQuestion2 = Random.Range(0, prefabQuiz1.Length);
                            choicesPanel[i].text = choices1[randomAnotherQuestion2];
                        } while (randomAnotherQuestion2 == randomAnotherQuestion1 || randomAnotherQuestion2 == randomQueston);
                    }
                    else if (j == 3)
                    {
                        do
                        {
                            randomAnotherQuestion3 = Random.Range(0, prefabQuiz1.Length);
                            choicesPanel[i].text = choices1[randomAnotherQuestion3];
                        } while (randomAnotherQuestion3 == randomQueston || randomAnotherQuestion3 == randomAnotherQuestion1 || randomAnotherQuestion3 == randomAnotherQuestion2);
                    }
                }
            }
        }
        else if (randomquest == 2)
        {
            int randomQueston = Random.Range(0, prefabQuiz2.Length);
            int randomPanel = Random.Range(0, choicesPanel.Length);
            answers[randomPanel].answer = true;
            int randomAnotherQuestion1 = 0;
            int randomAnotherQuestion2 = 0;
            int randomAnotherQuestion3 = 0;
            int k = 0;
            int l = 0;

            choicesPanel[randomPanel].text = choices2[randomQueston];
            GameObject item = Instantiate(prefabQuiz2[randomQueston],
                    new Vector3(200, 780, -400),
                    prefabQuiz2[randomQueston].transform.rotation) as GameObject;

            int j = 0;
            for (int i = 0; i <= 3; i++)
            {
                if (i != randomPanel)
                {
                    answers[i].answer = false;
                    j++;
                    if (j == 1)
                    {
                        do
                        {
                            k = i;
                            randomAnotherQuestion1 = Random.Range(0, prefabQuiz2.Length);
                            choicesPanel[i].text = choices2[randomAnotherQuestion1];
                        } while (randomAnotherQuestion1 == randomQueston || choicesPanel[i].text == choicesPanel[randomPanel].text);
                    }
                    else if (j == 2)
                    {
                        do
                        {
                            l = i;
                            randomAnotherQuestion2 = Random.Range(0, prefabQuiz2.Length);
                            choicesPanel[i].text = choices2[randomAnotherQuestion2];
                        } while (randomAnotherQuestion2 == randomAnotherQuestion1 || randomAnotherQuestion2 == randomQueston || choicesPanel[i].text == choicesPanel[randomPanel].text || choicesPanel[i].text == choicesPanel[k].text);
                    }
                    else if (j == 3)
                    {
                        do
                        {
                            randomAnotherQuestion3 = Random.Range(0, prefabQuiz2.Length);
                            choicesPanel[i].text = choices2[randomAnotherQuestion3];
                        } while (randomAnotherQuestion3 == randomQueston || randomAnotherQuestion3 == randomAnotherQuestion1 || randomAnotherQuestion3 == randomAnotherQuestion2 || choicesPanel[i].text == choicesPanel[randomPanel].text || choicesPanel[i].text == choicesPanel[k].text || choicesPanel[i].text == choicesPanel[l].text);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        benar = 0;
        QuizStart();
    }

}
