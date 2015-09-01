using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	bool update = false;
	GameObject go;
	float factor;
	float distance = 0f;
	GameObject prefab;
	BoxCollider Trigger;
	Rigidbody rb;
	LayerMask lm;
	LayerMask dp;
	LineRenderer lr;
	
	// Use this for initialization
	void Start () {
		prefab = GameObject.FindGameObjectWithTag ("Prefab");
		prefab.tag = "Cube";
		dp = 1 << LayerMask.NameToLayer ("Doorportal");
		dp = ~dp;
		lm = 1 << LayerMask.NameToLayer ("Inactive") | 1 << LayerMask.NameToLayer("Doorportal") | 1 << LayerMask.NameToLayer("Ignore Raycast");
		lm = ~lm; //reverse
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray rayy = Camera.main.ScreenPointToRay (new Vector3 (Camera.main.pixelWidth*3 / 5, Camera.main.pixelHeight*2 / 5, 0));
		lr.SetPosition (0, rayy.origin);
		if (controller.hasWeapon) {
			factor = controller.player.GetComponent<Playermovement>().factor;
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				if (go == null) {
					RaycastHit hit;
					if (Physics.Raycast (ray.origin, Camera.main.transform.forward, out hit, 200f, lm)) {
						if (hit.collider.gameObject.tag == "Cube" || hit.collider.gameObject.tag == "Lasercube") {
							go = hit.collider.gameObject;
							pick ();
						}
					}
				} else {
					release ();
				}
			}
		
			if (go != null) {
				distance = (go.transform.position - ray.origin).magnitude;
			}
			if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
				if (update) {
					distance += Input.GetAxis ("Mouse ScrollWheel") * 10f * factor;
					if (distance <= 1f * factor) {
						if (go.tag != "Lasercube") {
							controller.cubes += 1;
							Destroy (go);
							update = false;
						} else {
							distance = 1f * factor;
						}
					}
				} else {
					if (controller.cubes > 0 && Input.GetAxis ("Mouse ScrollWheel") > 0) {
						RaycastHit hit;
						if (Physics.Raycast (ray.origin, Camera.main.transform.forward, out hit, 200f, lm)) {
							if((ray.origin - hit.point).magnitude > 2f){
								GameObject cube = (GameObject)Instantiate (prefab, transform.position + transform.forward * 2f * factor , Quaternion.identity);
								go = cube;
								go.transform.localScale *= factor;
								controller.cubes -= 1;
								distance = 3f * factor;
								pick ();
							}
						}
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.Mouse1) && update) {
				if (controller.blockCamera) {
					controller.blockCamera = false;
				} else {
					controller.blockCamera = true;
				}
			}
			if(controller.oncube == go && go != null){
				release();
			}
		}
	}
	
	void FixedUpdate(){
		if (controller.hasWeapon) {
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));
			Vector3 pos = ray.origin + Camera.main.transform.forward * distance;
			Vector3 coll = Vector3.zero;
			if (update) {
				lr.enabled = true;
				RaycastHit cubeHit;
				if (Physics.Raycast (ray.origin, Camera.main.transform.forward, out cubeHit, 200f, lm)) {
					if (cubeHit.collider.gameObject != go) {
						RaycastHit hit;
						if (Physics.Raycast (go.transform.position, pos - go.transform.position, out hit, (pos - go.transform.position).magnitude, dp)) {
							coll = (hit.point - go.transform.position);
						}
						if (Physics.Raycast (go.transform.position + coll, (pos - go.transform.position) - coll, out hit, (pos - go.transform.position - coll).magnitude, dp)) {
							pos = hit.point;
						}
					}
				}
				Vector3 force = pos - go.transform.position;
				rb.velocity = Playermovement.velocity;
				rb.AddForce (force * 1 / (10 * Time.fixedDeltaTime), ForceMode.VelocityChange);
				rb.angularVelocity = Vector3.Lerp (rb.angularVelocity, Vector3.zero, Time.fixedDeltaTime * 10);
				//rb.transform.RotateAround(controller.player.transform.position, Vector3.up, Playermovement.angularVelocity.y);
				//rb.angularVelocity = Vector3.Lerp (rb.angularVelocity, Vector3.zero, Time.fixedDeltaTime * 10);
				if (controller.blockCamera) {
					if(controller.slow){
						rb.AddTorque (0f, -Input.GetAxis ("Mouse X") * factor, 0f);
					}else{
						rb.AddTorque (0f, -Input.GetAxis ("Mouse X") * 10f * factor, 0f);
					}
				}
				lr.SetPosition (1, go.transform.position);
			}else lr.enabled = false;
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

		controller.blockCamera = false;
	}
}

