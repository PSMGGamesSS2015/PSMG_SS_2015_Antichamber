using UnityEngine;
using System.Collections;

public class Cubepicker : MonoBehaviour {

	bool update = false; //cube picked?
	GameObject go; //active cube
	BoxCollider Trigger; //floortrigger
	Rigidbody rb; //cubes rigidbody
	AudioSource take;

	void Start () {
		go = null;
		take = GetComponents<AudioSource> () [2];
	}
	
	// only doing something if player has no weapon
	void Update () {
		if (!controller.hasWeapon) {
			//press e
			if (Input.GetKeyDown (KeyCode.E)) {
				if (go == null) {//-> no cube active
					Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));
					RaycastHit hit;
					if (Physics.Raycast (ray.origin, Camera.main.transform.forward, out hit, 2.0f)) { //hit something at distance 2 or lower
						if (hit.collider.gameObject.tag == "Cube" || hit.collider.gameObject.tag == "Lasercube") {//hit a cube or lasercube
							go = hit.collider.gameObject; // hit cube is now active cube
							pick (); 
						}
					}
				} else { // -> cube is active -> release it
					release ();
				}
			}
			if(controller.oncube == go && go != null){ //if the player stands on a cube he can't manipulate it
				release();
			}
		}
	}
	
	// only doing something if player has no weapon
	void FixedUpdate(){
		if (!controller.hasWeapon) {
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));
			Vector3 pos = ray.origin + Camera.main.transform.forward * 2; //middle of screen + distance of 2
			if (update) { //->cube is active
				Vector3 force = pos - go.transform.position; //Vector the cube has to be moved
				if (force.magnitude < 3f) { //if the velocity is not too high the cube gets manipulated
					rb.velocity = Playermovement.velocity; //cube moving with player's velocity
					rb.AddForce (force * 1 / (10 * Time.fixedDeltaTime), ForceMode.VelocityChange); //adding the forcevector (multiplied with scales to smooth the movement)
					rb.angularVelocity = Vector3.Lerp (rb.angularVelocity, Playermovement.angularVelocity, Time.fixedDeltaTime * 10); //adding rotation; lerp it to zero (multiplied with scales to smooth the movement)
				} else { //velocity too high ->release
					rb.velocity = Vector3.zero;
					release ();
				}
			} 
		}
	}

	//picking the cube; setting all necessary values
	void pick(){
		foreach(BoxCollider col in go.GetComponents<BoxCollider> ()){
			if(col.isTrigger){
				Trigger = col;
				Trigger.enabled = false; // disabling the floortrigger (to deactivate the cubescript)
			}
		}
		update = true;
		rb = go.GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.isKinematic = false;
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		take.Play ();
	}

	//reversing pick()
	void release(){
		Trigger.enabled = true;
		Trigger = null;

		update = false;

		rb.useGravity = true;
		rb = null;
		go = null;
		take.Play ();
	}

	public void stop(GameObject g){
		if (g == go) {
			release();
		}
	}
}