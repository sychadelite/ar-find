using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GPSScene : MonoBehaviour
{
	public Text GPSStatus;
	public Text longitudeValue;
	public Text keterangan;
	//public GameObject tutorial;
    
	void Start()
    {	
        StartCoroutine(GPSLoc());

    }

	
	IEnumerator GPSLoc(){
		if(!Input.location.isEnabledByUser){
			GPSStatus.text = "Aplikasi Find membutuhkan akses lokasi";
			keterangan.text = "Harap mengaktifkan GPS High Accuracy Anda";
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reload scene after enable GPS
				yield return new  WaitForSeconds(5);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);

			yield break;
		}
		Input.location.Start();
		int maxWait = 20;
		while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0){
			
			yield return new  WaitForSeconds(1);
			maxWait--;	
		}
		if(maxWait < 1){
			GPSStatus.text = "Time Out";
			yield break;
		}
		if(Input.location.status == LocationServiceStatus.Failed){
			GPSStatus.text = "Tidak dapat menentukan lokasi";
			yield break;
		}else{
			//access granted
			GPSStatus.text = "Anda berada di Summarecon Mall Serpong";
			InvokeRepeating("UpdateGPSData",0.5f,1f);
		}
	}

    // Update is called once per frame
    private void UpdateGPSData()
    {
		if(Input.location.status == LocationServiceStatus.Running){
			GPSStatus.text = "Anda berada di Summarecon Mall Serpong";
			longitudeValue.text = Input.location.lastData.longitude.ToString();
			
			string test = longitudeValue.text;
			test = test.Substring(0,7);

      if (test == "106.627" || test == "106.628") { //Longitude SMS
        SceneManager.LoadScene("LoginScene");
	  }else if(test == "106.629"){ //Longitude SMS
		SceneManager.LoadScene("LoginScene");
      }else if (test == "106.689" || test == "109.978") {
        SceneManager.LoadScene("LoginScene");
      }
      else {
        GPSStatus.text = "Anda sedang tidak berada di Summarecon Mall Serpong";
        keterangan.text = "Untuk dapat menjalankan aplikasi, Anda harus berada di Summarecon Mall Serpong";
      }
			
		}else{
			GPSStatus.text = "Stop";
		}
        
    }
}
