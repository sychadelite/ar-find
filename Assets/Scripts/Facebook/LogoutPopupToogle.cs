using UnityEngine;

public class LogoutPopupToogle : MonoBehaviour
{
  public GameObject popup;
  public void IsLogoutPopupShow(bool condition)
  {
    popup.SetActive(condition);
  }
}
