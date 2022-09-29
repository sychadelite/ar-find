using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSound : MonoBehaviour
{
    [SerializeField] AudioSource[] GuitarSfx;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Angklung")
            {
                GuitarSfx[0].Play();
            }
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Demung")
            {
                GuitarSfx[1].Play();
            }
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Geso")
            {
                GuitarSfx[2].Play();
            }
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Kolintang")
            {
                GuitarSfx[3].Play();
            }
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Panting")
            {
                GuitarSfx[4].Play();
            }
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Saluang")
            {
                GuitarSfx[5].Play();
            }
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Tifa")
            {
                GuitarSfx[6].Play();
            }
        }
    }
}
