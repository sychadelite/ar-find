using System.Collections;
using UnityEngine;
using Vuforia;


public class LoadAssets : MonoBehaviour
{
	public string assetName;
	public string url;
	public GameObject spawnner;
	public string parent;
	private GameObject setAsChild;


	public void imagefound()
	{
		spawnner.SetActive(true);
		WWW www = new WWW(url);
		StartCoroutine(RequestService(www)); 
	}
	  
	IEnumerator RequestService(WWW www)
	{
		yield return www;

		while (!www.isDone)
		{
		  yield return null;
		}

		AssetBundle assets = www.assetBundle;

		if (string.IsNullOrEmpty(www.error))
		{
		
			//set GameObject as Child of ImageTarget
			var target =  GameObject.Find((parent)).transform;
		 
			GameObject obj = (GameObject)assets.LoadAsset(assetName); 
			  
			setAsChild = Instantiate(obj, target);
			
			Object.Destroy(spawnner);
			/*
			float x = spawnner.transform.position.x;
			float y = spawnner.transform.position.y;
			float z = spawnner.transform.position.z;

			Instantiate(obj, new Vector3(x, y, z), Quaternion.identity);
			*/  
		}
		else
		{
			Debug.Log(www.error);
		}
	}
}
