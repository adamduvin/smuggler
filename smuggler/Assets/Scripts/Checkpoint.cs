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
    public bool atPointThree;
    public bool atPointFour;
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
        atPointThree = false;
        atPointFour = false;
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
            if(atPointOne || atPointTwo || atPointThree || atPointFour)
            {
                playerAtCheckpoint = true;
                player.atCheckpoint = true;
                gameManager.alertText.text = "Search in Progress";
                gameManager.SetAlertUIVisible(true, false);
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

            gameManager.SetAlertUIVisible(false, false);

            if (atPointOne)
            {
                Vector3 position = locations[2].position;
                position.x -= locations[2].GetComponent<BoxCollider2D>().size.x / 2;
                position.z = player.gameObject.transform.position.z;
                player.gameObject.transform.position = position;
            }
            else if (atPointTwo)
            {
                Vector3 position = locations[1].position;
                position.x += locations[1].GetComponent<BoxCollider2D>().size.x / 2;
                position.z = player.gameObject.transform.position.z;
                player.gameObject.transform.position = position;
            }
            else if (atPointThree)
            {
                Vector3 position = locations[4].position;
                position.y -= locations[4].GetComponent<BoxCollider2D>().size.y / 2;
                position.z = player.gameObject.transform.position.z;
                player.gameObject.transform.position = position;
            }
            else if (atPointFour)
            {
                Vector3 position = locations[3].position;
                position.y += locations[3].GetComponent<BoxCollider2D>().size.y / 2;
                position.z = player.gameObject.transform.position.z;
                player.gameObject.transform.position = position;
            }

            atPointOne = false;
            atPointTwo = false;
            atPointThree = false;
            atPointFour = false;
        }
    }
}