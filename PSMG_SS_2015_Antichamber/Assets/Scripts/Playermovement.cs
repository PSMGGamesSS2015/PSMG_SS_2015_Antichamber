using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

public class Playermovement : MonoBehaviour {
	
	float speed = 6.0f; //movementspeed
	public float gravity = 9.8f; //gravity
	float maxVelocityChange = 1.0f; 
	float jumpHeight = 1.0f;
	public float factor = 1.0f; //factor (if player is small: 1/10)
	public static Vector3 velocity;
	public static Vector3 angularVelocity;
	Rigidbody rb;
	AudioSource run;
	AudioSource jump;
	
	
	
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
		rb.useGravity = false;
		run = GetComponents<AudioSource> ()[0];
		jump = GetComponents<AudioSource> ()[1];
	}
	
	void FixedUpdate () {
		if (!controller.blockCamera) {
			rb.angularVelocity = Vector3.up * Input.GetAxis ("Mouse X");
		} else {
			rb.angularVelocity = Vector3.zero;
		}
		// Calculate how fast we should be moving
		Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetVelocity = transform.TransformDirection(targetVelocity);
		targetVelocity *= speed*factor;
			
		// Apply a force that attempts to reach our target velocity
		Vector3 vel = GetComponent<Rigidbody>().velocity;
		Vector3 velocityChange = (targetVelocity - vel);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange*factor, maxVelocityChange*factor);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange*factor, maxVelocityChange*factor);
		velocityChange.y = 0;
		rb.AddForce(velocityChange, ForceMode.VelocityChange);
		rb.velocity = applyMaxSpeed (rb.velocity);
			// Jump

		
		// We apply gravity manually for more tuning control
		rb.AddForce(new Vector3 (0, -gravity * GetComponent<Rigidbody>().mass, 0));
			
		velocity = rb.velocity;
		angularVelocity = rb.angularVelocity;
	}

	void Update(){
		if (JumpTrigger.grounded && Input.GetKeyDown(KeyCode.Space)) {
			jump.Play();
			GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			speed = 2f;
			controller.slow = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			speed = 6f;
			controller.slow = false;
		}
		if (velocity.magnitude > 0.3f && JumpTrigger.grounded) {
			if(!run.isPlaying){
				run.Play ();
			}
		}else run.Stop();
	}

	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * factor * gravity);
	}

	Vector3 applyMaxSpeed(Vector3 velocity){
		Vector3 horizontalVelocity = new Vector3(velocity.x, 0f, velocity.z);
		if (horizontalVelocity.magnitude > speed) {
			horizontalVelocity.Normalize();
			horizontalVelocity *= speed*factor;
		}
		return new Vector3(horizontalVelocity.x, velocity.y, horizontalVelocity.z);
	}
}