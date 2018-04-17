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
    Vector2 direction;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boundingBox = gameObject.GetComponent<BoxCollider2D>();
        mainCamera = Camera.main;
        position = transform.position;
        maxVelocity = 10.0f;
        maxForce = 20.0f;
        rotationValue = 0.0f;
        rotationStep = 0.5f;
        maxRotationValue = 1.0f;
        direction = rb.transform.up;
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

            rb.MoveRotation(rb.rotation + rotationValue);

            //Vector3 rotation = rb.transform.right * rotationValue;
            //Debug.Log(rotation);
            /*Vector2 pastVelocity = rb.velocity;
            if(pastVelocity.magnitude == 0.0f)
            {
                pastVelocity = direction;
            }
            //Debug.Log(rotationValue);
            //rb.AddForce(rb.transform.right * rotationValue);
            Vector2 currentVelocity = rb.velocity;
            if(currentVelocity.magnitude == 0.0f)
            {
                currentVelocity = pastVelocity;
            }
            float rotationAngle = Vector2.Dot(pastVelocity, currentVelocity) / (pastVelocity.magnitude * currentVelocity.magnitude);
            Debug.Log(rotationAngle);*/

            //direction = rb.velocity.normalized;
            //float rotationAngle += rb.transform.up + currentVelocity; //Vector2.Dot(rb.transform.up, currentVelocity) / (rb.transform.up.magnitude * currentVelocity.magnitude);
            //Debug.Log(rotationAngle);
            //Debug.Log("Up: " + rb.transform.up);
            //rb.MoveRotation(rotationAngle);
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

            rb.MoveRotation(rb.rotation + rotationValue);
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
            rotationValue = -maxRotationValue;
            if (rotationValue > -maxRotationValue)
            {
                rotationValue -= rotationStep; // * Time.deltaTime;
                //float deltaRotationValue = -rotationValue * Time.deltaTime;
                //rb.MoveRotation(rb.rotation + deltaRotationValue);
            }

            else
            {
                rotationValue = -maxRotationValue;
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            if (rotationValue < maxRotationValue)
            {
                rotationValue += rotationStep; // * Time.deltaTime;
                //float deltaRotationValue = rotationValue * Time.deltaTime;
                //rb.MoveRotation(rb.rotation + deltaRotationValue);
            }

            else
            {
                rotationValue = maxRotationValue;
            }
        }

        else
        {
            rotationValue = 0.0f;
            /*if (rotationValue < 0.1f && rotationValue > -0.1f)
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
            }*/
        }
    }
}
