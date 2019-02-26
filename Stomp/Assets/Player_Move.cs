using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

	public float playerSpeed = 8.0f;
	private float moveX;
	public float moveY;

	[Range(1,10)]
	public float jumpForce;
	public bool isGrounded;

	public float dashTime = 0.25f;
	public float currentDashTime;
	public bool dashing = false;
	public float time;
	public float dashSpeed = 18.0f;
	public float speed;
	//public float vSpeed = 0.0f;

	void Start(){
		currentDashTime = 0f;
		speed = playerSpeed;
	}


	void Update () {
		time = Time.time;
		PlayerMove();
	}
	void PlayerMove(){

		moveX = Input.GetAxis("P1_Horizontal");
		//moveY = Input.GetAxis("Vertical");


		if (Input.GetButtonDown ("Jump") && isGrounded == true){
			GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
		}

		if (Input.GetKeyDown(KeyCode.Q) && !dashing)
		{
			currentDashTime = Time.time + dashTime;
			dashing = true;
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				GetComponent<Rigidbody2D>().velocity = Vector2.up * 20;
			}
		}

		if(Time.time > currentDashTime && dashing){
			dashing = false;
		}

		if(dashing){
			speed = dashSpeed;
		}

		if(!dashing){
			speed = playerSpeed;
		}

		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		//gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (gameObject.GetComponent<Rigidbody2D>().velocity.x, moveY * vSpeed);
	}

	void OnCollisionEnter2D(Collision2D theCollision)
	{
		if(theCollision.gameObject.tag == "ground"){
			isGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D theCollision)
	{
		if(theCollision.gameObject.tag == "ground"){
			isGrounded = false;
		}
	}
}
