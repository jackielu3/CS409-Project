using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Reference to the TextMeshProUGUI component

    // Method to update the timer text
    public void UpdateTimer(float remainingTime)
    {
        // Format time as minutes:seconds
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        // Update the timer UI text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to clear the timer UI
    public void ClearTimer()
    {
        timerText.text = "";
    }
}