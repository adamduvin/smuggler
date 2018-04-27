﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    private float timer;
    public Text timerText;
    public int notoriety;
    public int score;
    public Text scoreText;
    public Text alertText;
    public Image suppliesIndicator;
    private bool makeVisible;
    private bool wait;
    private Color textColor;
    private Color suppliesColor;

    // Use this for initialization
    void Start () {
        timer = 60.0f;
        timerText.text = "Time: " + Mathf.Ceil(timer);
        notoriety = 0;
        score = 0;
        scoreText.text = "Score: " + score;
        alertText.text = "Supplies Acquired";
        makeVisible = false;
        wait = false;
        textColor = alertText.color;
        suppliesColor = suppliesIndicator.color;
    }
	
	// Update is called once per frame
	void Update () {
        DecrementTime();
	}

    void DecrementTime()
    {
        if(timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }

        else
        {
            timer = 0.0f;
        }
        float timerCiel = Mathf.Ceil(timer);
        float minute = Mathf.Floor(timerCiel / 60.0f);
        float second = Mathf.Ceil(timerCiel % 60.0f);

        timerText.text = "Time: 0" + minute + ":";
        if(second < 10)
        {
            timerText.text += "0";
        }
        timerText.text += second;
    }

    public void IncrementScore()
    {
        score += 100;
        scoreText.text = "Score: " + score;
    }

    public void SetAlertUIVisible(bool visible)
    {
        if (visible)
        {
            makeVisible = true;
            textColor = alertText.color;
            textColor.a = 1.0f;
            alertText.color = textColor;

            Color suppliesColor = suppliesIndicator.color;
            suppliesColor.a = 1.0f;
            suppliesIndicator.color = suppliesColor;
        }

        else
        {
            makeVisible = false;
            Color textColor = alertText.color;
            textColor.a = 0.0f;
            alertText.color = textColor;

            suppliesColor = suppliesIndicator.color;
            suppliesColor.a = 0.0f;
            suppliesIndicator.color = suppliesColor;
        }
    }

    private void LerpTextOpacity(bool visible, Color color)
    {

    }
}
