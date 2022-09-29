using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistem : MonoBehaviour
{
    public static Sistem instance;
    public int ID;
    public GameObject SpawnPlace;
    public GameObject GUI_Utama;
    public GameObject MarkerOne; // Waypoint 1
    public GameObject MarkerTwo; // Waypoint 2
    public GameObject MarkerThree; // Waypoint 3
    public GameObject MarkerFour; // Waypoint 4
    public GameObject MarkerFive; // Waypoint 5
    public GameObject CanvasIntro; // Canvas First Time Navigate
    public GameObject CanvasMarkerOne; // Canvas Waypoint 1
    public GameObject CanvasMarkerTwo; // Canvas Waypoint 2
    public GameObject CanvasMarkerThree; // Canvas Waypoint 3
    public GameObject CanvasMarkerFour; // Canvas Waypoint 4
    public GameObject CanvasMarkerFive; // Canvas Waypoint 5
    public GameObject CanvasSelectNavigationOne; // Canvas Selecting Navigation
    public GameObject CanvasSelectNavigationTwo; // Canvas Selecting Navigation
    public GameObject CanvasSelectNavigationThree; // Canvas Selecting Navigation
    public GameObject CanvasSelectNavigationFour; // Canvas Selecting Navigation
    public GameObject CanvasSelectNavigationFive; // Canvas Selecting Navigation
    public GameObject CanvasFeatureInformation; // Canvas Feature Information
    public GameObject GuideSearchImage; // Perintah Menemukan Image Target Navigasi
    public GameObject GuideFollowWaypoint; // Perintah Berjalan Mengikuti Waypoint
    public GameObject ButtonReset; // Reset Button
    public GameObject Tooltip; // Tooltip Tutorial
    public GameObject[] KoleksiObject;

    // ---- The Way ----
    public GameObject WayOneToTwo;
    public GameObject WayOneToThree;
    public GameObject WayOneToFour;
    public GameObject WayOneToFive;

    public GameObject WayTwoToOne;
    public GameObject WayTwoToThree;
    public GameObject WayTwoToFour;
    public GameObject WayTwoToFive;

    public GameObject WayThreeToOne;
    public GameObject WayThreeToTwo;
    public GameObject WayThreeToFour;
    public GameObject WayThreeToFive;

    public GameObject WayFourToOne;
    public GameObject WayFourToTwo;
    public GameObject WayFourToThree;
    public GameObject WayFourToFive;
    
    public GameObject WayFiveToOne;
    public GameObject WayFiveToTwo;
    public GameObject WayFiveToThree;
    public GameObject WayFiveToFour;

    // Agar dapat memanggil class sitem yang memiliki object bernama instance
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ID = 0;
        GUI_Utama.SetActive(false);
    }

    public void SpawnObject()
    {
        GameObject BendaSebelumnya = GameObject.FindGameObjectWithTag("Alat");
        if (BendaSebelumnya != null) Destroy(BendaSebelumnya);

        GameObject Benda = Instantiate(KoleksiObject[ID]);
        Benda.transform.SetParent(SpawnPlace.transform, false);
        Benda.transform.localScale = new Vector3(2, 2, 2); // Local Scale untuk menyamakan ukuran object pada child tempat spawn
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchObject(true);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchObject(false);
        }
    }

    public void SwitchObject (bool Kanan)
    {
        if (Kanan)
        {
            if(ID >= KoleksiObject.Length - 1)
            {
                ID = 0;
            }
            else
            {
                ID++;
            }
        }

        else
        {
            if(ID <= 0)
            {
                ID = KoleksiObject.Length - 1;
            }
            else
            {
                ID--;
            }
        }

        SpawnObject();
    }

}
