using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour {

	public Player player;
    public Manager gameManager;
    private int uses;

	// Use this for initialization
	void Start () {
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        GameObject managerObj = GameObject.Find("GameManager");
        gameManager = managerObj.GetComponent<Manager>();
        uses = 2;
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (player.hasSupplies)
            {
                gameManager.IncrementScore();
                uses--;
                player.hasSupplies = false;
                gameManager.SetAlertUIVisible(false, false);
                if (uses <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
