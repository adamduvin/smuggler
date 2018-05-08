using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    private float timer;
    public Text timerText;
    public int notoriety;
    public int score;
    public Text alertText;
    public Image suppliesIndicator;
    private bool makeVisible;
    private float wait;
    private float percent;
    private Color textColor;
    private Color suppliesColor;
    public GameObject player;
    public Image scoreCounter;

    // Use this for initialization
    void Start () {
        timer = 300.0f;
        timerText.text = "Time: " + Mathf.Ceil(timer);
        notoriety = 0;
        score = 0;
        alertText.text = "Supplies Acquired";
        makeVisible = false;
        wait = 1.0f;
        percent = 0.0f;
        textColor = alertText.color;
        suppliesColor = suppliesIndicator.color;
    }
	
	// Update is called once per frame
	void Update () {
        DecrementTime();
        if (makeVisible)
        {
            LerpTextOpacity(textColor);
        }
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
			SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
        }
        float timerCiel = Mathf.Ceil(timer);
        float minute = Mathf.Floor(timerCiel / 60.0f);
        float second = Mathf.Ceil(timerCiel % 60.0f);

        timerText.text = "0" + minute + ":";
        if(second < 10)
        {
            timerText.text += "0";
        }
        timerText.text += second;
    }

    public void IncrementScore()
    {
        score += 1;
        //scoreText.text = "Score: " + score;

        Vector2 position = scoreCounter.transform.position;
        position.x += 14.19f;
        scoreCounter.transform.position = position;

        if(score == 8)
        {
            SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
        }
    }

    public void SetAlertUIVisible(bool visible, bool suppliesGet)
    {
        if (visible)
        {
            textColor = alertText.color;
            textColor.a = 1.0f;
            alertText.color = textColor;

            if (suppliesGet)
            {
                makeVisible = true;
                Color suppliesColor = suppliesIndicator.color;
                suppliesColor.a = 1.0f;
                suppliesIndicator.color = suppliesColor;
            }
        }

        else
        {
            //makeVisible = false;
            textColor = alertText.color;
            textColor.a = 0.0f;
            alertText.color = textColor;

            suppliesColor = suppliesIndicator.color;
            suppliesColor.a = 0.0f;
            suppliesIndicator.color = suppliesColor;
        }
    }

    private void LerpTextOpacity(Color color)
    {
        if(wait >= 0.0f)
        {
            wait -= Time.deltaTime;
        }

        else
        {
            if(percent < 1.0f)
            {
                Color alertTextColor = alertText.color;
                alertTextColor.a = Mathf.Lerp(1.0f, 0.0f, percent);
                percent += 0.5f * Time.deltaTime;
                alertText.color = alertTextColor;
            }

            else
            {
                percent = 0.0f;
                wait = 1.0f;
                makeVisible = false;
            }
        }
    }
}
