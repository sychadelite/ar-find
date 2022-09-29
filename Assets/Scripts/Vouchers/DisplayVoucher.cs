using UnityEngine;
using UnityEngine.UI;

public class DisplayVoucher : MonoBehaviour
{
  public Text TvoucherName;
  public Text TvoucherCompany;

  public GameObject ObjDuration;

  void Update()
  {
    ObjDuration.SetActive(true);
    string voucherType = PlayerPrefs.GetString("voucher_type");
    string voucherName = PlayerPrefs.GetString("voucher_name");
    string voucherDesc = PlayerPrefs.GetString("voucher_desc");
    string voucherCompany = PlayerPrefs.GetString("voucher_company");

    if (voucherType.Equals("Coins"))
    {
      TvoucherCompany.gameObject.SetActive(false);
      ObjDuration.SetActive(false);
    }

    Debug.Log(voucherName);
    TvoucherName.text = (voucherName.Length > 45 && !voucherType.Equals("Coins")) ? voucherName.Substring(0, 45) + "..." : voucherName;
    TvoucherCompany.text = (voucherCompany.Length > 25 && !voucherType.Equals("Coins")) ? voucherCompany.Substring(0, 10) + "..." : voucherCompany;
  }
}
