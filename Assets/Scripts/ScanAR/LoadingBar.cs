using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
	public static LoadingBar Instance;
	[SerializeField] private GameObject _loaderCanvas;
	[SerializeField] private Image _progressBar;
	private float target;
    
	void Awake(){
		if(Instance==null){
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else{
			Destroy(gameObject);
		}
	}
	
	public async void LoadScene(string sceneName){
		target = 0;
		_progressBar.fillAmount = 0;
		
		var scene = SceneManager.LoadSceneAsync(sceneName);
		scene.allowSceneActivation = false;
		
		_loaderCanvas.SetActive(true);
		
		do{
			//await Task.Delay(100);
			target = scene.progress;
		} while (scene.progress < 0.9f);
		
		
		scene.allowSceneActivation = true;
		_loaderCanvas.SetActive(false);
	}
	
	void Update(){
		_progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount,target,3 * Time.deltaTime);
	}
}
