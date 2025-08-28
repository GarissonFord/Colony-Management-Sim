using UnityEngine;

public class TestListener : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        GameClock.OnClockChangeEvent += ConfirmingThatWeHeardTheEvent;
    }

    private void OnDisable()
    {
        GameClock.OnClockChangeEvent -= ConfirmingThatWeHeardTheEvent;
    }

    private void ConfirmingThatWeHeardTheEvent(GameClock gameClock)
    {
        Debug.Log("We've got the clock changed event! The current time is " + gameClock.CurrentGameTime);
    }
}
