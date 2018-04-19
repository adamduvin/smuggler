using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public Player player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//if(Collision) collision logic
		if(player.hasSupplies)
		{
			//Application.LoadLevel("gameOver");
			Debug.Log("1");
		}
	}
}