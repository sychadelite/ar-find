using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] prefab;
    int prefabRandom;
    public Transform[] panel;
    int panelRandom;
    bool trick = true;
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            if (!trick)
            {
                prefabRandom = Random.Range(0, prefab.Length);
                //panelRandom = Random.Range(0, panel.Length);
                int randomOffsetX = Random.Range(30, 600);
                int randomOffsetY = Random.Range(0, 500);

                GameObject item = Instantiate(prefab[prefabRandom],
                new Vector3(randomOffsetX, randomOffsetY, -400),
                prefab[prefabRandom].transform.rotation) as GameObject;

                //item.transform.SetParent(panel[panelRandom], true);
                yield return new WaitForSeconds(4);
            }
            else
            {
                trick = false;
                prefabRandom = Random.Range(0, prefab.Length);
                //panelRandom = Random.Range(0, panel.Length);
                int randomOffsetX = Random.Range(30, 600);
                int randomOffsetY = Random.Range(0, 500);

                GameObject item = Instantiate(prefab[prefabRandom],
                new Vector3(randomOffsetX, randomOffsetY, 0),
                prefab[prefabRandom].transform.rotation) as GameObject;

                item.transform.SetParent(panel[panelRandom], true);
                item.SetActive(false);
                yield return new WaitForSeconds(1);
            }
        }
    }

}
