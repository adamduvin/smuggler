using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D boundingBox;
    private Camera mainCamera;
    private Vector3 position;
    private float steering; 

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boundingBox = gameObject.GetComponent<BoxCollider2D>();
        mainCamera = Camera.main;
        position = transform.position;
        steering = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {

    }

    void Move()
    {

    }
}
