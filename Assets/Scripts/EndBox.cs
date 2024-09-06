using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBox : MonoBehaviour
{

    public ColorManager colorManager;

    // Tag to check for
    public string ballTag = "Ball";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ballTag))
        {
            Ball ball = other.GetComponent<Ball>();

            string ballColor = ball.ballColor.ToString();


            if (ball != null && !ball.isBeingHeld)
            {
                Debug.Log("Ball color: " + ballColor);

                colorManager.ballInBox(ballColor);
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(ballTag))
        {
            Ball ball = other.GetComponent<Ball>();

            if (ball != null && !ball.isBeingHeld)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
