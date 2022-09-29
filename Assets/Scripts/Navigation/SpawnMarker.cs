using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMarker : MonoBehaviour
{
    public void DeactivateCanvasIntro()
    {
        Sistem.instance.CanvasIntro.SetActive(false);
    }

    public void ActivateMarkerOne()
    {
        // Aktifkan Marker One
        Sistem.instance.MarkerOne.SetActive(false);
        Sistem.instance.CanvasMarkerOne.SetActive(true);
        Sistem.instance.GuideFollowWaypoint.SetActive(true);
        Sistem.instance.ButtonReset.SetActive(true);

        // DeactivateCanvasIntro();
        // DeactivateMarkerOne();
        DeactivateMarkerTwo();
        DeactivateMarkerThree();
        DeactivateMarkerFour();
        DeactivateMarkerFive();
    }

    public void DeactivateMarkerOne()
    {
        // Nonaktifkan Marker One
        Sistem.instance.MarkerOne.SetActive(false);
        Sistem.instance.CanvasMarkerOne.SetActive(false);
    }

    // -------------------------------------------------------

    public void ActivateMarkerTwo()
    {
        // Aktifkan Marker Two
        Sistem.instance.MarkerTwo.SetActive(false);
        Sistem.instance.CanvasMarkerTwo.SetActive(true);
        Sistem.instance.GuideFollowWaypoint.SetActive(true);
        Sistem.instance.ButtonReset.SetActive(true);

        // DeactivateCanvasIntro();
        DeactivateMarkerOne();
        // DeactivateMarkerTwo();
        DeactivateMarkerThree();
        DeactivateMarkerFour();
        DeactivateMarkerFive();
    }

    public void DeactivateMarkerTwo()
    {
        // Nonaktifkan Marker Two
        Sistem.instance.MarkerTwo.SetActive(false);
        Sistem.instance.CanvasMarkerTwo.SetActive(false);
    }

    // -------------------------------------------------------

    public void ActivateMarkerThree()
    {
        // Aktifkan Marker Three
        Sistem.instance.MarkerThree.SetActive(false);
        Sistem.instance.CanvasMarkerThree.SetActive(true);
        Sistem.instance.GuideFollowWaypoint.SetActive(true);
        Sistem.instance.ButtonReset.SetActive(true);

        // DeactivateCanvasIntro();
        DeactivateMarkerOne();
        DeactivateMarkerTwo();
        // DeactivateMarkerThree();
        DeactivateMarkerFour();
        DeactivateMarkerFive();
    }

    public void DeactivateMarkerThree()
    {
        // Nonaktifkan Marker Three
        Sistem.instance.MarkerThree.SetActive(false);
        Sistem.instance.CanvasMarkerThree.SetActive(false);
    }

    // -------------------------------------------------------

    public void ActivateMarkerFour()
    {
        // Aktifkan Marker Four
        Sistem.instance.MarkerFour.SetActive(false);
        Sistem.instance.CanvasMarkerFour.SetActive(true);
        Sistem.instance.GuideFollowWaypoint.SetActive(true);
        Sistem.instance.ButtonReset.SetActive(true);

        // DeactivateCanvasIntro();
        DeactivateMarkerOne();
        DeactivateMarkerTwo();
        DeactivateMarkerThree();
        // DeactivateMarkerFour();
        DeactivateMarkerFive();
    }

    public void DeactivateMarkerFour()
    {
        // Nonaktifkan Marker Four
        Sistem.instance.MarkerFour.SetActive(false);
        Sistem.instance.CanvasMarkerFour.SetActive(false);
    }

    // -------------------------------------------------------

    public void ActivateMarkerFive()
    {
        // Aktifkan Marker Five
        Sistem.instance.MarkerFive.SetActive(false);
        Sistem.instance.CanvasMarkerFive.SetActive(true);
        Sistem.instance.GuideFollowWaypoint.SetActive(true);
        Sistem.instance.ButtonReset.SetActive(true);

        // DeactivateCanvasIntro();
        DeactivateMarkerOne();
        DeactivateMarkerTwo();
        DeactivateMarkerThree();
        DeactivateMarkerFour();
        // DeactivateMarkerFive();
    }

    public void DeactivateMarkerFive()
    {
        // Nonaktifkan Marker Five
        Sistem.instance.MarkerFive.SetActive(false);
        Sistem.instance.CanvasMarkerFive.SetActive(false);
    }


    // --------------------------------------------------------

    public void DeactivateAllMarker()
    {
        // Aktifkan Canvas Intro
        Sistem.instance.CanvasIntro.SetActive(true);
        // Nonaktifkan Semua Marker
        Sistem.instance.MarkerOne.SetActive(false);
        Sistem.instance.MarkerTwo.SetActive(false);
        Sistem.instance.MarkerThree.SetActive(false);
        Sistem.instance.MarkerFour.SetActive(false);
        Sistem.instance.MarkerFive.SetActive(false);
        // Nonaktifkan Semua Canvas
        Sistem.instance.CanvasMarkerOne.SetActive(false);
        Sistem.instance.CanvasMarkerTwo.SetActive(false);
        Sistem.instance.CanvasMarkerThree.SetActive(false);
        Sistem.instance.CanvasMarkerFour.SetActive(false);
        Sistem.instance.CanvasMarkerFive.SetActive(false);
        // Aktifkan Guide Search Image Target Navigation
        Sistem.instance.GuideSearchImage.SetActive(true);
        // Nonaktifkan Guide Follow Waypoint
        Sistem.instance.GuideFollowWaypoint.SetActive(false);
        // Nonaktifkan Button Reset
        Sistem.instance.ButtonReset.SetActive(false);
    }
}
