using UnityEngine;
using System.Collections;

//activates the meshrenderer and boxcollider if the player is near and moving slow
public class invisibleWay : MonoBehaviour {
	MeshRenderer mr;
	BoxCollider bc;

	void  OnEnable () {
		mr = GetComponent<MeshRenderer> ();
		mr.enabled = false;

		bc = GetComponent<BoxCollider> ();
		bc.enabled = false;
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && controller.slow) {
			mr.enabled = true;
			bc.enabled = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			mr.enabled = false;
			bc.enabled = false;
		}
	}
}
