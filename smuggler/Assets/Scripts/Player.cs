using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D boundingBox;
    private Camera mainCamera;
    private Vector3 position;
    private float maxVelocity;
    private float maxForce;
    private float rotationValue;
    private float rotationStep;
    private float maxRotationValue;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boundingBox = gameObject.GetComponent<BoxCollider2D>();
        mainCamera = Camera.main;
        position = transform.position;
        maxVelocity = 10.0f;
        maxForce = 20.0f;
        rotationValue = 0.0f;
        rotationStep = 5.0f;
        maxRotationValue = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.magnitude > 0 && rb.velocity.normalized == -(Vector2)rb.transform.up)
            {
                rb.AddForce(-rb.velocity.normalized * maxForce);
            }

            else
            {
                rb.AddForce(rb.transform.up * maxForce);
                if (rb.velocity.magnitude > maxVelocity)
                {
                    rb.velocity.Normalize();
                    rb.velocity *= maxVelocity;
                }
            }

            Vector3 rotation = rb.transform.right * rotationValue;
            Debug.Log(rotation);
            rb.AddForce(rb.transform.transform.right * rotationValue);
            rb.MoveRotation(rotation.x);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.magnitude > 0 && rb.velocity.normalized == (Vector2)rb.transform.up)
            {
                rb.AddForce(-rb.velocity.normalized * maxForce);
            }

            else
            {
                rb.AddForce(-rb.transform.up * maxForce);
                if (rb.velocity.magnitude > maxVelocity)
                {
                    rb.velocity.Normalize();
                    rb.velocity *= maxVelocity;
                }
            }
        }

        else
        {
            if (rb.velocity.magnitude <= 0.1f)
            {
                rb.velocity = Vector2.zero;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (rotationValue > -maxRotationValue)
            {
                rotationValue -= rotationStep * Time.deltaTime;
                //float deltaRotationValue = -rotationValue * Time.deltaTime;
                //rb.MoveRotation(rb.rotation + deltaRotationValue);
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            if (rotationValue < maxRotationValue)
            {
                rotationValue += rotationStep * Time.deltaTime;
                //float deltaRotationValue = rotationValue * Time.deltaTime;
                //rb.MoveRotation(rb.rotation + deltaRotationValue);
            }
        }

        else
        {
            if (rotationValue < maxRotationValue || rotationValue > -maxRotationValue)
            {
                rotationValue = 0.0f;
            }

            if (rotationValue > 0.0f)
            {
                rotationValue -= rotationStep * Time.deltaTime;
            }

            else if (rotationValue < 0.0f)
            {
                rotationValue += rotationStep * Time.deltaTime;
            }
        }
    }
}
