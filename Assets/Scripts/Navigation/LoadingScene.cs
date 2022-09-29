using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene instance;

    [SerializeField] private GameObject loaderCanvas;
    [SerializeField] private GameObject progressBar;

    void Awake()
    {
        if(instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        loaderCanvas.SetActive(true);

        do {
            await Task.Delay(100);
            // progressBar.fillAmount = scene.progress;
        } while (scene.progress < 0.9f);

        // await Task.Delay(1000);

        scene.allowSceneActivation = true;
        loaderCanvas.SetActive(false);
    }
}
