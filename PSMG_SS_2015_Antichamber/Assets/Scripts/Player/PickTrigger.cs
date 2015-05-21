using UnityEngine;
using System.Collections;

public class PickTrigger : MonoBehaviour {
	
	public static bool interact = false; //true if the player can pick up a cube
	public static bool releasable = false; //true if the player has picked a cube
	Rigidbody controller;
	GameObject cube;
	BoxCollider Trigger;
	
	void Start () {
		controller = gameObject.GetComponentsInParent<Rigidbody> ()[0];
	}
	
	void FixedUpdate(){
		if (releasable) {
			move(); // moves the carried cube with the player
			if(Input.GetKeyDown(KeyCode.E)){
				release ();// releases the carried cube
			}
		}
		else{
			if (interact) {
				if(Input.GetKeyDown(KeyCode.E)){
					pick (); // picks the interacting cube inside the player's interaction range
				}
			}
		}
	}

	//if there is already a interacting cube in the player's range return
	//else set the colliding cube to the interacting cube
	void OnTriggerStay(Collider other) {
		if (cube != null) {
			return;
		}
		if (other.gameObject.tag == "Cube") {
			interact = true;
			cube = other.gameObject;
		}
	}

	//if the cube gets out of the player's interaction range relase it
	void OnTriggerExit(Collider other) {
		if (other.gameObject == cube) {
			if(releasable){
				release ();
			}
			else{
				cube = null;
				interact = false;
			}
		}
	}

	//reactivates gravity and the cube's ground trigger
	void release(){
		releasable = false;
		Rigidbody rb = cube.GetComponent<Rigidbody>();
		rb.useGravity = true;
		cube = null;
		Trigger.enabled = true;
	}

	//picks the cube: deactivates the cube's gravity and ground trigger
	//freezes the cube's x and z rotation to prevent it from rotating crazy
	void pick(){
		releasable = true;
		interact = false;
		Rigidbody rb = cube.GetComponent<Rigidbody>();
		rb.useGravity = false;
		foreach (BoxCollider a in cube.GetComponents<BoxCollider> ()) {
			if(a.isTrigger){
				Trigger = a;
				Trigger.enabled = false;
			}
		};
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		rb.isKinematic = false;
	}

	//moves and rotates the cube depending on the player's movement
	void move(){
		Rigidbody rb = cube.GetComponent<Rigidbody>();
		rb.velocity = Playermovement.velocity;
		rb.transform.RotateAround(controller.transform.position, Vector3.up, Playermovement.angularVelocity.y);
		rb.angularVelocity = Vector3.Lerp (rb.angularVelocity, Vector3.zero, Time.fixedDeltaTime*10);
	}
}

