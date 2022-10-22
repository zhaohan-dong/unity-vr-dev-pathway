using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minuteHand;
    public GameObject secondHand;
    public int timeZoneOffset;
    private int oldSecond;
    private int second;
    private int minute;
    private int hour;

    // Update is called once per frame
    void Update()
    {
        second = Convert.ToInt32(System.DateTime.UtcNow.ToString("ss"));
        if (second != oldSecond)
        {
            UpdateTimer();
            oldSecond = second;
        }
    }

    void UpdateTimer()
    {
        minute = Convert.ToInt32(System.DateTime.UtcNow.ToString("mm"));
        hour = Convert.ToInt32(System.DateTime.UtcNow.ToString("hh")) + timeZoneOffset;
        secondHand.transform.localEulerAngles = new Vector3(90 + (float)(second * 6), 0, -90);
        minuteHand.transform.localEulerAngles = new Vector3(90 + (float)(minute * 6 + second * 0.1), 0, -90);
        hourHand.transform.localEulerAngles = new Vector3(90 + (float)(hour * 30 + minute * 0.5 + second / 120), 0, -90);
    }
}
