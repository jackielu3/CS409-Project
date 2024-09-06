using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    public GameObject gameUIobj;
    public GameObject resultUIobj;

    public BallColorUI colorUI;
    public PointUI pointUI;
    public TimerUI timerUI;
    public ResultUI resultUI;

    private string[] availableColors = { "Red", "Blue", "Yellow" };
    private Queue<string> selectedColors;

    public bool status;

    public int points;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        status = false;
        points = 0;

        GenerateRandomColors();
    }

    public void GenerateRandomColors()
    {
        int numberOfColors = UnityEngine.Random.Range(1, 4);
        selectedColors = new Queue<string>();

        // Randomly select the colors
        for (int i = 0; i < numberOfColors; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, availableColors.Length);
            selectedColors.Enqueue(availableColors[randomIndex]);
        }
    }

    public Queue<string> GetColors()
    {
        return selectedColors;
    }

    public void ballInBox(string ballColor)
    {
        if (selectedColors.Peek() == ballColor)
        {
            selectedColors.Dequeue();

            Debug.Log("Ball Accepted");

            if (selectedColors.Count == 0)
            {
                pointAdd();
            }
        }
        else 
        {

            Debug.Log("Ball rejected");

            SetStatus(false);
            StartCoroutine(colorUI.DisplayRedX());
        }
    }

    public void SetStatus(bool s)
    {
        status = s;
    }

    public void pointAdd()
    {
        if (status)
        {
            points++;
            Debug.Log("Point added: " + points);
            
            pointUI.DisplayPoint(points);
            GenerateRandomColors();
            colorUI.DisplayColors();
        }
    }

    // Function to start the 2-minute timer and enable status
    public void StartGameTimer()
    {
        // Enable status at the beginning of the timer
        SetStatus(true);

        // Start the 2-minute timer coroutine
        StartCoroutine(GameTimer(10f));
    }

    // Coroutine to handle the 2-minute timer
    private IEnumerator GameTimer(float duration)
    {
        Debug.Log("Timer started: Status is enabled");

        float remainingTime = duration;

        while (remainingTime > 0)
        {
            // Update the timer UI
            timerUI.UpdateTimer(remainingTime);

            // Wait for 1 second
            yield return new WaitForSeconds(1f);

            // Decrease the remaining time
            remainingTime -= 1f;
        }

        // After 2 minutes, disable status and clear the timer UI
        SetStatus(false);
        timerUI.ClearTimer();
        Debug.Log("Timer ended: Status is disabled");

        GameOver();
    }

    public int GetPoints()
    {
        return points;
    }

    public void GameOver()
    {
        resultUIobj.SetActive(true);
        gameUIobj.SetActive(false);
    }

}
