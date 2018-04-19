using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplies : MonoBehaviour {

	public Player player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//if(Collision) collision logic
		player.hasSupplies = true;
	}
}