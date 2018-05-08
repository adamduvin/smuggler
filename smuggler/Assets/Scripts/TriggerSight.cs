using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSight : MonoBehaviour {

    public Sprite unseen;
    public Sprite seen;
    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = gameObject.GetComponentInParent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sr.sprite = seen;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sr.sprite = unseen;
        }
    }
}
