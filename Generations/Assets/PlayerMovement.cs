using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed = 2;
    public float jumpStrength = 20;
    private Rigidbody2D rb;
    private float horizontalAxis;
    private bool canJump = false;
    private bool willJump = false;

	// Use this for initialization
	void Start () {
	    rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }

    void FixedUpdate() {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, 0);

        if (canJump && moveVertical > 0)
            Jump();

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb.velocity = movement*movementSpeed;
    }

    void Jump() {
        canJump = false;
        rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        Debug.Log("Jump!" + rb.velocity);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            canJump = true;
            Debug.Log("Can jump true");
        }
    }
}
