using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour {

	public Player player;
    public Manager gameManager;
    private bool playerAtCheckpoint;
    private float timer;
    private float maxTime;
    public bool atPointOne;
    public bool atPointTwo;
    private Transform[] locations;

    // Use this for initialization
    void Start () {
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        GameObject managerObj = GameObject.Find("GameManager");
        gameManager = managerObj.GetComponent<Manager>();
        playerAtCheckpoint = false;
        maxTime = timer = 3;
        atPointOne = false;
        atPointTwo = false;
        locations = gameObject.GetComponentsInChildren<Transform>();
    }

	// Update is called once per frame
	void Update () {
        if (playerAtCheckpoint)
        {
            TickTimer();
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(atPointOne || atPointTwo)
            {
                playerAtCheckpoint = true;
                player.atCheckpoint = true;
                gameManager.alertText.text = "Search in Progress";
                gameManager.SetAlertUIVisible(true);
                if (player.hasSupplies)
                {
					SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
                }
            }
        }
    }

    private void TickTimer()
    {
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            timer = maxTime;
            playerAtCheckpoint = false;
            player.atCheckpoint = false;

            gameManager.SetAlertUIVisible(false);

            if (atPointOne)
            {
                player.gameObject.transform.position = locations[2].position;
            }
            else if (atPointTwo)
            {
                player.gameObject.transform.position = locations[1].position;
            }

            atPointOne = false;
            atPointTwo = false;
        }
    }
}