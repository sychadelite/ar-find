using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCanvasInformation : MonoBehaviour
{
    public void OpenInformation()
    {
        // Aktifkan Canvas Select Navigation
        Sistem.instance.CanvasFeatureInformation.SetActive(true);

        Sistem.instance.Tooltip.SetActive(false);

        Sistem.instance.CanvasSelectNavigationOne.SetActive(false);
        Sistem.instance.CanvasSelectNavigationTwo.SetActive(false);
        Sistem.instance.CanvasSelectNavigationThree.SetActive(false);
        Sistem.instance.CanvasSelectNavigationFour.SetActive(false);
        Sistem.instance.CanvasSelectNavigationFive.SetActive(false);
    }

    public void CloseInformation()
    {
        // Aktifkan Canvas Select Navigation
        Sistem.instance.CanvasFeatureInformation.SetActive(false);

        Sistem.instance.Tooltip.SetActive(false);

        Sistem.instance.CanvasSelectNavigationOne.SetActive(false);
        Sistem.instance.CanvasSelectNavigationTwo.SetActive(false);
        Sistem.instance.CanvasSelectNavigationThree.SetActive(false);
        Sistem.instance.CanvasSelectNavigationFour.SetActive(false);
        Sistem.instance.CanvasSelectNavigationFive.SetActive(false);
    }
}
