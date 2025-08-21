using UnityEngine;
using TMPro;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] private TMP_Text clockText;
    [SerializeField] private DateTime currentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DateTime timeAtStart = DateTime.Now;
        clockText = GetComponent<TMP_Text>();
        setClockText(timeAtStart.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.Now;
        setClockText(currentTime.ToString());
    }

    private void setClockText(String time)
    {
        clockText.text = time;
    }
}
