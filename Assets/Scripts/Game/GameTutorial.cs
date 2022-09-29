using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTutorial : MonoBehaviour
{
    public GameObject Tutorial;
    public GameObject ConfirmationText;
    public GameObject MulaiButton;
    public GameObject BackButton;
    public GameObject PanelHijau;

    public void PushAyoBermain(){
        Tutorial.SetActive(true);
        ConfirmationText.SetActive(true);
        MulaiButton.SetActive(true);
        BackButton.SetActive(true);
        PanelHijau.SetActive(true);
    }

    public void PushKembali(){
        Tutorial.SetActive(false);
        ConfirmationText.SetActive(false);
        MulaiButton.SetActive(false);
        BackButton.SetActive(false);
        PanelHijau.SetActive(false);
    }
}
