using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenePlay : MonoBehaviour
{
    public void ChangePlayMode()
    {
        SceneManager.LoadSceneAsync("ProtoGameBaru");
    }

    public void ChangeARmode()
    {
        SceneManager.LoadScene("ScanAR");
    }

}
