using System.Collections;
using Facebook.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FacebookLogout : MonoBehaviour
{
  public void CallLogout()
  {
    StartCoroutine(FBLogout());
  }

  IEnumerator FBLogout()
  {
    FB.LogOut();
    while (FB.IsLoggedIn)
    {
      Debug.Log("Loading...");
      yield return null;
    }
    PlayerPrefs.DeleteAll();
    SceneManager.LoadScene(1);
  }
}
