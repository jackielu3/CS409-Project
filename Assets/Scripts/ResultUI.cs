using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public ColorManager colorManager;

    public TextMeshProUGUI resultTextDisplay;

    private int points;
    
    // Start is called before the first frame update
    void Start()
    {
        points = colorManager.GetPoints();
        resultTextDisplay = this.GetComponent<TextMeshProUGUI>();

        Display();
    }

    void Display()
    {
        resultTextDisplay.text = "GAME OVER\r\n\r\n" + points + " Points Scored\r\n";
    }

    
}
