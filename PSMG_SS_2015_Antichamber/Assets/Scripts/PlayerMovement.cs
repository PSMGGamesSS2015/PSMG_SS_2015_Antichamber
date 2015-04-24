using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	// Use this for initialization

	GameObject player;
	CharacterController controller;
	float speed = 3.0f;
	float jumpSpeed = 3.5f;
	float gravity = 9.8f;
	float yspeed;
	Vector3 moveDirection = Vector3.zero;


	void Start () {
		player = gameObject;
		controller = player.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//rotate player left or right
		player.transform.Rotate(0f, Input.GetAxis ("Mouse X"), 0f);

		yspeed = moveDirection.y;

		moveDirection = new Vector3(Input.GetAxis("Horizontal")*speed, yspeed,
		                             Input.GetAxis("Vertical")*speed);
		
		moveDirection = transform.TransformDirection(moveDirection);

		if (controller.isGrounded) {				
			if (Input.GetKeyDown ("space")) {
					moveDirection.y = jumpSpeed;
			}
		}
			
			// Apply gravity
			moveDirection.y -= gravity * Time.deltaTime;
			
			// Move the controller
			controller.Move(moveDirection * Time.deltaTime);
	}
}
