using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMovement : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, rb.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.velocity += new Vector2 (0, 20);
		}
	}
}
