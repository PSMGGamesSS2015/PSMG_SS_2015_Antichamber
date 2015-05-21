using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

public class Playermovement : MonoBehaviour {
	
	public float speed = 5.0f; 
	public float gravity = 9.8f;
	public float maxVelocityChange = 2.0f;
	public float jumpHeight = 2.0f;
	public static Vector3 velocity;
	public static Vector3 angularVelocity;
	
	
	
	void Awake () {
		GetComponent<Rigidbody>().freezeRotation = true;
		GetComponent<Rigidbody>().useGravity = false;
	}
	
	void FixedUpdate () {
		//rotation
		GetComponent<Rigidbody> ().angularVelocity = Vector3.up * Input.GetAxis ("Mouse X");
		// Calculate how fast we should be moving
		Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetVelocity = transform.TransformDirection(targetVelocity);
		targetVelocity *= speed;
			
		// Apply a force that attempts to reach our target velocity
		Vector3 vel = GetComponent<Rigidbody>().velocity;
		Vector3 velocityChange = (targetVelocity - vel);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
		GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

			// Jump
			if (JumpTrigger.grounded && Input.GetButton("Jump")) {
				GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}

		
		// We apply gravity manually for more tuning control
		GetComponent<Rigidbody>().AddForce(new Vector3 (0, -gravity * GetComponent<Rigidbody>().mass, 0));
			
		velocity = GetComponent<Rigidbody>().velocity;
		angularVelocity = GetComponent<Rigidbody>().angularVelocity;
	}

	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}