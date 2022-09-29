using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCanvasSelectNavigation : MonoBehaviour
{
    public void OpenSelectingOne()
    {
        // Aktifkan Canvas Select Navigation
        Sistem.instance.CanvasSelectNavigationOne.SetActive(true);
        Sistem.instance.GuideSearchImage.SetActive(false);
        Sistem.instance.CanvasFeatureInformation.SetActive(false);

        // CloseSelectingOne();
        CloseSelectingTwo();
        CloseSelectingThree();
        CloseSelectingFour();
        CloseSelectingFive();
    }

    public void CloseSelectingOne()
    {
        // Nonaktifkan Canvas Select Navigation
        Sistem.instance.CanvasSelectNavigationOne.SetActive(false);
    }

    public void OpenSelectingTwo()
    {
        // Aktifkan Canvas Select Navigation
        Sistem.instance.CanvasSelectNavigationTwo.SetActive(true);
        Sistem.instance.GuideSearchImage.SetActive(false);
        Sistem.instance.CanvasFeatureInformation.SetActive(false);

        CloseSelectingOne();
        // CloseSelectingTwo();
        CloseSelectingThree();
        CloseSelectingFour();
        CloseSelectingFive();
    }

    public void CloseSelectingTwo()
    {
        // Nonaktifkan Canvas Select Navigation
        Sistem.instance.CanvasSelectNavigationTwo.SetActive(false);
    }

    public void OpenSelectingThree()
    {
        // Aktifkan Canvas Select Navigation
        Sistem.instance.CanvasSelectNavigationThree.SetActive(true);
        Sistem.instance.GuideSearchImage.SetActive(false);
        Sistem.instance.CanvasFeatureInformation.SetActive(false);

        CloseSelectingOne();
        CloseSelectingTwo();
        // CloseSelectingThree();
        CloseSelectingFour();
        CloseSelectingFive();
    }

    public void CloseSelectingThree()
    {
        // Nonaktifkan Canvas Select Navigation
        Sistem.instance.CanvasSelectNavigationThree.SetActive(false);
    }

    public void OpenSelectingFour()
    {
        // Aktifkan Canvas Select Navigation
        Sistem.instance.CanvasSelectNavigationFour.SetActive(true);
        Sistem.instance.GuideSearchImage.SetActive(false);
        Sistem.instance.CanvasFeatureInformation.SetActive(false);

        CloseSelectingOne();
        CloseSelectingTwo();
        CloseSelectingThree();
        // CloseSelectingFour();
        CloseSelectingFive();
    }

    public void CloseSelectingFour()
    {
        // Nonaktifkan Canvas Select Navigation
        Sistem.instance.CanvasSelectNavigationFour.SetActive(false);
    }

    public void OpenSelectingFive()
    {
        // Aktifkan Canvas Select Navigation
        Sistem.instance.CanvasSelectNavigationFive.SetActive(true);
        Sistem.instance.GuideSearchImage.SetActive(false);
        Sistem.instance.CanvasFeatureInformation.SetActive(false);

        CloseSelectingOne();
        CloseSelectingTwo();
        CloseSelectingThree();
        CloseSelectingFour();
        // CloseSelectingFive();
    }

    public void CloseSelectingFive()
    {
        // Nonaktifkan Canvas Select Navigation
        Sistem.instance.CanvasSelectNavigationFive.SetActive(false);
    }
}
