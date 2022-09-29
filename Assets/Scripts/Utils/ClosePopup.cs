using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosePopup : MonoBehaviour
{
  public void ClosePopupFunc(string popupObj)
  {
    GameObject.Find(popupObj).SetActive(false);

    if (SceneManager.GetActiveScene().Equals(3))
    {
      ResetVoucherKeys();
    }
  }

  void ResetVoucherKeys()
  {
    PlayerPrefs.DeleteKey("voucher_type");
    PlayerPrefs.DeleteKey("voucher_name");
    PlayerPrefs.DeleteKey("voucher_desc");
    PlayerPrefs.DeleteKey("voucher_company");
  }
}
