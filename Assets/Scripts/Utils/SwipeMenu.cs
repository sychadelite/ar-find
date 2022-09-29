using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
  public GameObject ScrollBar;
  float scrollPos = 0;
  float[] pos;

  void Update()
  {
    Debug.Log("Width : " + Screen.width + " Height : " + Screen.height);

    pos = new float[transform.childCount];
    float distance = 1f / (pos.Length - 1);

    for (int i = 0; i < pos.Length; i++)
    {
      pos[i] = distance * i;
    }

    if (Input.GetMouseButton(0))
    {
      scrollPos = ScrollBar.GetComponent<Scrollbar>().value;
    }
    else
    {
      for (int i = 0; i < pos.Length; i++)
      {
        if ((scrollPos < pos[i] + distance / 2) && (scrollPos > pos[i] - (distance / 2)))
        {
          ScrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(ScrollBar.GetComponent<Scrollbar>().value, pos[i], 0.15f);
          transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
        }
        else
        {
          transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(0.95f, 0.95f), 0.1f);
        }
      }
    }
  }
}
