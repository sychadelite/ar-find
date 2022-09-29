using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    // Start is called before the first frame update
		//public GameObject asset;
		public GameObject InfoAsset;
		public void OpenInfo(){
			if(InfoAsset !=null){
				bool isActive = InfoAsset.activeSelf;
				InfoAsset.SetActive(!isActive);
			
			}
		}

		
		
    // Update is called once per frame

}
