using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move2 : MonoBehaviour {

	public int playerSpeed = 10;
	private float moveX;
	public float moveY;
	public float jumpForce = 10;
	public KeyCode W;

	// Update is called once per frame
	void Update () {
		PlayerMove2();
	}
	void PlayerMove2(){
		//CONTROLS
		moveX = Input.GetAxis("P2_Horizontal");
		if (Input.GetKeyDown(W)){
			Jump();
		}
		//PHYSICS
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void Jump(){
		//Jumping Code
		GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
	}
}
