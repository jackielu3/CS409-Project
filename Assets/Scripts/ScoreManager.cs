using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ResultUI resultUI;
    [SerializeField] private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;


    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, resultUI.points);
    }

}
