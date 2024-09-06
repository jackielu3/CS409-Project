using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Text;
using System.Collections;

public class BallColorUI : MonoBehaviour
{
    public TextMeshProUGUI colorTextDisplay; 
    public ColorManager colorManager;

    private string[] colorNames = { "Red", "Blue", "Yellow"};

    void Start()
    {
        DisplayColors();
    }

    public void DisplayColors()
    {
        Queue<string> selectedColors = colorManager.GetColors();

        string colorDisplayText = "Add these Colors in order!\n\n";

        StringBuilder result = new StringBuilder();

        foreach (string color in selectedColors)
        {
            if (result.Length > 0)
            {
                result.Append(" + ");
            }
            result.Append(color);
        }

        string colorString = result.ToString();

        colorTextDisplay.text = colorDisplayText + colorString;
    }

    public IEnumerator DisplayRedX()
    {
        Debug.Log("Displaying X");

        colorTextDisplay.text = "<color=red><size=100>X</size></color>";

        yield return new WaitForSeconds(3f);

        colorManager.GenerateRandomColors();
        colorManager.SetStatus(true);
        DisplayColors();

    }

    /*
    string GetColorName(Color color)
    {
        // Return the name of the color
        if (color == Color.red) return "Red";
        if (color == Color.blue) return "Blue";
        if (color == Color.yellow) return "Yellow";
        return "Unknown";
    }
    */
}
