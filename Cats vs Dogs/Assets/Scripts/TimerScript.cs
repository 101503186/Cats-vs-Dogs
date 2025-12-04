using System;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] bool isRunning = true;
    [SerializeField] TMP_Text timerText;
    [SerializeField] float time;

    TimeSpan timespan;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            time += Time.deltaTime;

            timespan = TimeSpan.FromSeconds(time);

            timerText.text = string.Format("{0:D2}:{1:D2}", timespan.Minutes, timespan.Seconds);
        }
    }
}
