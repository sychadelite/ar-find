using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using EasyUI.Toast;

public class CheckAvailabilityARCore : MonoBehaviour
{
    public GameObject AlertDialogSupport;
    public GameObject AlertDialogNotSupport;

    IEnumerator Start() {
        yield return IsARCoreSupported();
        if (IsARCoreSupported() == true)
        {
            AlertDialogSupport.SetActive(true);
            yield return new WaitForSeconds(1);
            AlertDialogSupport.SetActive(false);

            Sistem.instance.Tooltip.SetActive(true);
            yield return new WaitForSeconds(10);
            Sistem.instance.Tooltip.SetActive(false);
            // Toast.Show ("<b>Fitur ini mendukung pada perangkat anda</b>", 2f, ToastColor.Green, ToastPosition.MiddleCenter);
        }
        else
        {
            AlertDialogNotSupport.SetActive(true);
            // Toast.Show ("<b>Fitur ini tidak mendukung pada perangkat anda</b>", 2f, ToastColor.Red, ToastPosition.MiddleCenter);
        }

        // yield return ARSession.CheckAvailability();
        // Toast.Show ($"<b>ARSession.CheckAvailability() finished with state: {ARSession.state}</b>", 2f, ToastColor.Green, ToastPosition.MiddleCenter);
        // Debug.Log($"ARSession.CheckAvailability() finished with state: {ARSession.state}");
   
        // // ARSession.CheckAvailability() can finish with state ARSessionState.Installing if an update for AR Services is required. So we wait.
        // while (ARSession.state == ARSessionState.Installing) {
        //     yield return null;
        // }
   
        // if (ARSession.state == ARSessionState.NeedsInstall) {
        //     Toast.Show ("<b>Installing AR provider...</b>", 2f, ToastColor.Green, ToastPosition.MiddleCenter);
        //     Debug.Log("Installing AR provider...");
        //     yield return ARSession.Install();
        // }
   
        // // Toast.Show("ARCore is supported in this device", 2f, ToastColor.Green);
        // Toast.Show ($"<b>ARCore is supported in this device:</b>  {ARSession.state >= ARSessionState.Ready}", 2f, ToastColor.Green, ToastPosition.MiddleCenter) ;
        // Debug.Log($"AR is supported in this device: {ARSession.state >= ARSessionState.Ready}");
    }
 

    // ------------------------------------- First Method -------------------------------------------

    // private void OnEnable()
    // {
    //     ARSubsystemManager.CreateSubsystems();
    //     StartCoroutine(ARSubsystemManager.CheckAvailability());
    //     StartCoroutine(AllowARScene());
    // }
 
    // IEnumerator AllowARScene()
    // {
    //     while (true)
    //     {
    //         while (ARSubsystemManager.systemState == ARSystemState.CheckingAvailability ||
    //             ARSubsystemManager.systemState == ARSystemState.None)
    //         {
    //             Debug.Log("Waiting...");
    //             yield return null;
    //         }
    //         if (ARSubsystemManager.systemState == ARSystemState.Unsupported)
    //         {
    //             Debug.Log("AR unsupported");
    //             yield break;
    //         }
    //         if (ARSubsystemManager.systemState > ARSystemState.CheckingAvailability)
    //         {
    //             Debug.Log("AR supported");
    //             yield break;
    //         }
    //     }      
    // }

// ----------------------------------------- Second Method -----------------------------------------------------

    public static bool IsARCoreSupported() 
    {
        var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        var packageManager = context.Call<AndroidJavaObject>("getPackageManager");
        AndroidJavaObject packageInfo = null;
        try
        {
            packageInfo = packageManager.Call<AndroidJavaObject>("getPackageInfo", "com.google.ar.core", 0);
        }
        catch
        {

        }
        if (packageInfo != null)
            return true;
        else
            return false;
    }
}
