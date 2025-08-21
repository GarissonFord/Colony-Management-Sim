using UnityEngine;
using System;
using TMPro;

public class GameClock : MonoBehaviour
{
    [SerializeField] private TMP_Text clockText;
    [SerializeField] private DateTime currentSystemTime;
    [SerializeField] private DateTime currentGameTime;
    [SerializeField] private float timeClockWasLastUpdated;
    [SerializeField] private float currentSystemTimeInSeconds;
    [SerializeField] private bool isRunning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGameTime = new DateTime(2025, 1, 1, 6, 0, 0);
        setClockText(currentGameTime.ToString());
        isRunning = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            currentSystemTime = DateTime.Now;

            // timeClockWasLastUpdated += Time.deltaTime;
            currentSystemTimeInSeconds = currentSystemTime.Second;

            if (currentSystemTimeInSeconds - timeClockWasLastUpdated >= 10.0f)
            {
                Debug.Log("Adding minutes");
                currentGameTime = currentGameTime.AddMinutes(10.0);
                Debug.Log("currentGameTime: " + currentGameTime);
                setClockText(currentGameTime.ToString());
            }
        }
    }

    private void setClockText(String time)
    {
        clockText.text = time;
        // currentGameTime = DateTime.Now;
        timeClockWasLastUpdated = DateTime.Now.Second;
    }

    public void OnPauseButtonClicked()
    {
        isRunning = !isRunning;

        if (isRunning)
        {
            timeClockWasLastUpdated = DateTime.Now.Second;
        }
    }
}
