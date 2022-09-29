using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActiveScene : MonoBehaviour
{

  void Start()
  {
    switch (SceneManager.GetActiveScene().buildIndex)
    {
      case 2:
        ActiveNavbar("Home");
        break;

      case 3:
        ActiveNavbar("Nav");
        break;

      case 4:
        ActiveNavbar("Reward");
        break;

      case 5:
        ActiveNavbar("Setting");
        break;

      case 6:
        ActiveNavbar("Scan");
        break;

      case 7:
        ActiveNavbar("Reward");
        break;

      case 9:
        ActiveNavbar("Reward");
        break;

      default:
        ActiveNavbar("Home");
        break;
    }
  }

  void ActiveNavbar(string objName)
  {
    Image navIcon = GameObject.Find(objName).GetComponent<Image>();
    Color active = navIcon.color;
    active.a = 1f;
    navIcon.color = active;
  }
}
