using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
  public void MoveScene(int buildIndex)
  {
    if (buildIndex != SceneManager.GetActiveScene().buildIndex)
    {
      SceneManager.LoadScene(buildIndex);
    }
  }
}
