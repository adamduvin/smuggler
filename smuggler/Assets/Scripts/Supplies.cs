using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplies : MonoBehaviour {

	public Player player;
    public Manager gameManager;

	// Use this for initialization
	void Start () {
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        GameObject managerObj = GameObject.Find("GameManager");
        gameManager = managerObj.GetComponent<Manager>();
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!player.hasSupplies)
            {
                player.hasSupplies = true;
                gameManager.SetAlertUIVisible(true);
                Destroy(gameObject);
            }
        }
    }
}