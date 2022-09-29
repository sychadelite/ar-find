﻿using UnityEngine;

public class FormatDateString : MonoBehaviour
{
  public static string FormatDate(int month)
  {
    switch (month)
    {
      case 1:
        return "Jan";

      case 2:
        return "Feb";

      case 3:
        return "Mar";

      case 4:
        return "Apr";

      case 5:
        return "Mei";

      case 6:
        return "Jun";

      case 7:
        return "Jul";

      case 8:
        return "Ags";

      case 9:
        return "Sep";

      case 10:
        return "Okt";

      case 11:
        return "Nov";

      case 12:
        return "Des";

      default:
        return "-";
    }
  }
}
