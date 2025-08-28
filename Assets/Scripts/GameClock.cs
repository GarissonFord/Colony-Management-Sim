using UnityEngine;
using System;
using TMPro;

public class GameClock : MonoBehaviour
{
    public static event Action<GameClock> OnClockChangeEvent;

    [SerializeField] private TMP_Text clockText;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private DateTime currentGameTime;
    public DateTime CurrentGameTime { get => currentGameTime; }

    [SerializeField] private float inGameSecondsSinceClockWasLastUpdated;   
    [SerializeField] private bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGameTime = new DateTime(2025, 1, 1, 6, 0, 0);
        setClockText(currentGameTime.ToString());
        isPaused = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            inGameSecondsSinceClockWasLastUpdated += Time.deltaTime;

            if (inGameSecondsSinceClockWasLastUpdated >= 10.0f)
            {
                currentGameTime = currentGameTime.AddMinutes(10.0);
                OnClockChangeEvent(this);
                setClockText(currentGameTime.ToString());
            }
        }
    }

    private void setClockText(String time)
    {
        clockText.text = time;
        inGameSecondsSinceClockWasLastUpdated = 0.0f;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }
}
