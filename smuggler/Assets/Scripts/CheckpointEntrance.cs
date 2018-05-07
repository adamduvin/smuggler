using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointEntrance : MonoBehaviour {

    private Checkpoint checkpoint;

	// Use this for initialization
	void Start () {
        checkpoint = GetComponentInParent<Checkpoint>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(gameObject.tag == "PointOne")
            {
                checkpoint.atPointOne = true;
            }
            else if (gameObject.tag == "PointTwo")
            {
                checkpoint.atPointTwo = true;
            }
            else if (gameObject.tag == "PointThree")
            {
                checkpoint.atPointThree = true;
            }
            else if (gameObject.tag == "PointFour")
            {
                checkpoint.atPointFour = true;
            }
        }
    }
}
