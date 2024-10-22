﻿using UnityEngine;
using System.Collections;


//is the player grounded and can jump?
public class JumpTrigger : MonoBehaviour {

	public static bool grounded;

	void  OnEnable () {
		grounded = false;
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Cube") {
			grounded = true;
			if(other.gameObject.tag == "Cube"){
				controller.oncube = other.gameObject;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Cube") {
			grounded = false;
			if(other.gameObject.tag == "Cube"){
				controller.oncube = null;
			}
		}
	}
}
