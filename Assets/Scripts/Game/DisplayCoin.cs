using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayCoin : MonoBehaviour
{
    public Text textScore;
    // Update is called once per frame
    void Update()
    {
        textScore.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
