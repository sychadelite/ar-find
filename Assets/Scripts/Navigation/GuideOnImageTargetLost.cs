using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideOnImageTargetLost : MonoBehaviour
{
    public void ActivateGuide()
    {
        // Aktifkan Guide Search Image Target Navigation
        Sistem.instance.GuideSearchImage.SetActive(true);
    }
}
