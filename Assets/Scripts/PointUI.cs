using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointUI : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
    }

    public void DisplayPoint(int points)
    {
        tmp.text = "" + points;
    }
}
