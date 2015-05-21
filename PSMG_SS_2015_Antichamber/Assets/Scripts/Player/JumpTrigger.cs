using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour {

	public static bool grounded;

	// Use this for initialization
	void Start () {
		grounded = false;//the player is grounded if the player is on the floor or on a cube
	}
	
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Cube") {
			grounded = true; 
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Cube") {
			grounded = false;
		}
	}
}
