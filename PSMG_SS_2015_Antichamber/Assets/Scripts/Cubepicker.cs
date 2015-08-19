using UnityEngine;
using System.Collections;

public class Cubepicker : MonoBehaviour {

	bool update = false;
	GameObject go;
	BoxCollider Trigger;
	Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		go = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (!controller.hasWeapon) {
			if (Input.GetKeyDown (KeyCode.E)) {
				if (go == null) {
					Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));
					RaycastHit hit;
					if (Physics.Raycast (ray.origin, Camera.main.transform.forward, out hit, 2.0f)) {
						if (hit.collider.gameObject.tag == "Cube" || hit.collider.gameObject.tag == "Lasercube") {
							go = hit.collider.gameObject;
							pick ();
						}
					}
				} else {
					release ();
				}
			}
		}
	}
	
	void FixedUpdate(){
		if (!controller.hasWeapon) {
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));
			Vector3 pos = ray.origin + Camera.main.transform.forward * 2;
			if (update) {
				Vector3 force = pos - go.transform.position;
				if (force.magnitude < 3f) {
					rb.velocity = Playermovement.velocity;
					rb.AddForce (force * 1 / (10 * Time.fixedDeltaTime), ForceMode.VelocityChange);
					rb.angularVelocity = Vector3.Lerp (rb.angularVelocity, Playermovement.angularVelocity, Time.fixedDeltaTime * 10);
					//rb.transform.RotateAround(controller.player.transform.position, Vector3.up, Playermovement.angularVelocity.y);
					//rb.angularVelocity = Vector3.Lerp (rb.angularVelocity, Vector3.zero, Time.fixedDeltaTime * 10);
				} else {
					rb.velocity = Vector3.zero;
					release ();
				}
			} 
		}
	}

	void pick(){
		foreach(BoxCollider col in go.GetComponents<BoxCollider> ()){
			if(col.isTrigger){
				Trigger = col;
				Trigger.enabled = false;
			}
		}
		update = true;
		rb = go.GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.isKinematic = false;
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}

	void release(){
		Trigger.enabled = true;
		Trigger = null;

		update = false;

		rb.useGravity = true;
		rb = null;
		go = null;
	}
}