using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeMaster : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;

    //public string saveLocation;
    public static TimeMaster instance;

    // Start is called before the first frame update
    void Awake()
    {
        //Create instances of Datemaster script
        instance = this;
    }


    //Check current time against the saved time
    //return differences in seconds (detik)
    public float CheckDate()
    {
        //Store current time when it starts

        currentDate = System.DateTime.Now;

        if (!PlayerPrefs.HasKey("savedTime"))
        {
            PlayerPrefs.SetString("savedTime", System.DateTime.Now.ToBinary().ToString());
        }
        string tempString = PlayerPrefs.GetString("savedTime");

        //Grab old time from playerpref as a long
        long tempLong = Convert.ToInt64(tempString);

        //Convert the old time from binary to a datetime
        DateTime oldDate = DateTime.FromBinary(tempLong);
        print("old Date : " + oldDate);

        //Use the substract method and store the result as a timespan
        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference : " + difference);

        return (float)difference.TotalSeconds;
    }

    //saves the current time,  
    public void SaveDate()
    {
        //save the current system time
        PlayerPrefs.SetString("savedTime", System.DateTime.Now.ToBinary().ToString());
        print("saving this date to playerprefs: " + System.DateTime.Now);
    }

}
