using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Freezes the cube if it hits the floor
	void OnTriggerStay(Collider other){
		if (!other.isTrigger) {
			rb.constraints = RigidbodyConstraints.FreezeAll;
			rb.isKinematic = true;
		}
	}

	//Unfreezes the cube if it is not touching the floor
	void OnTriggerExit(Collider other){
		if (!other.isTrigger) {
			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			rb.isKinematic = false;
		}
	}
}
