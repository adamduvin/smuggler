using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D boundingBox;
    private Camera mainCamera;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boundingBox = gameObject.GetComponent<BoxCollider2D>();
        mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Move()
    {

    }
}
