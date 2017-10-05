using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour {
    
    public Text timer;

    private float timeLeft = 15f;

	void Update () 
    {
        timer.text = "Time: " + timeLeft.ToString("F0");

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            //End Turn
            Debug.Log("End of turn");
            timeLeft = 15f;
        }
	}

    public void ResetTimer()
    {
        timeLeft = 15f;
    }
}
