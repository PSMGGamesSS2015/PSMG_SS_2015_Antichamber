using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour {

	public static bool grounded;

	// Use this for initialization
	void Start () {
		grounded = false;
	}
	
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Cube" || other.gameObject.tag == "Level4") {
			grounded = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Cube" || other.gameObject.tag == "Level4") {
			grounded = false;
		}
	}
}
