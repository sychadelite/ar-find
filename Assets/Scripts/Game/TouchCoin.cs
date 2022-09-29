using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCoin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int coinBefore = PlayerPrefs.GetInt("coins");
            if (Physics.Raycast(ray, out hit))
            {
                PlayerPrefs.SetInt("coins", coinBefore + 1);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
