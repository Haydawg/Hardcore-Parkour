using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
    public float seconds;
    public float minutes;
    public Text textClock;

    void Start()
    {

    }
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds > 59)
        {
            minutes += 1;
            seconds = 0;
        }
        textClock.text = minutes + ":" + String.Format("{0:0.00}", seconds);
    }
}