using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	bool update = false; //active cube?
	GameObject go; //active cube
	float factor; //1/10 if small
	float distance = 0f;
	public static GameObject prefab; //cube prefab
	BoxCollider Trigger; //cube's floor trigger
	Rigidbody rb; //cube's rigidbody
	LayerMask lm;
	LayerMask dp;
	LineRenderer lr; //weapon laser
	AudioSource rotating;
	AudioSource zoom;
	
	// Use this for initialization
	void  OnEnable () {
		prefab = GameObject.FindGameObjectWithTag ("Prefab");
		prefab.tag = "Cube";
		dp = 1 << LayerMask.NameToLayer ("Doorportal");
		dp = ~dp; //raycasts ignoring just doorportal
		lm = 1 << LayerMask.NameToLayer ("Inactive") | 1 << LayerMask.NameToLayer("Doorportal") | 1 << LayerMask.NameToLayer("Ignore Raycast");
		lm = ~lm; //raycasts ignoring inactive + doorportal + ignore raycast
		lr = GetComponent<LineRenderer> ();
		lr.enabled = false;
		rotating = GetComponents<AudioSource>()[3];
		zoom = GetComponents<AudioSource>()[4];
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.hasWeapon) {
			//start of weaponlaser
			Ray rayy = Camera.main.ScreenPointToRay (new Vector3 (Camera.main.pixelWidth*3 / 5, Camera.main.pixelHeight*2 / 5, 0));
			lr.SetPosition (0, rayy.origin);

			factor = controller.player.GetComponent<Playermovement>().factor;

			//left mouseclick picks or releases cubes
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				if (go == null) {
					RaycastHit hit;
					if (Physics.Raycast (ray.origin, Camera.main.transform.forward, out hit, 200f, lm)) { //max distance 200f; lm layermast used
						if (hit.collider.gameObject.tag == "Cube" || hit.collider.gameObject.tag == "Lasercube") {
							pick (hit.collider.gameObject);
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
					if(!zoom.isPlaying){
						zoom.Play();
					}
					//zooming the active cube
					distance += Input.GetAxis ("Mouse ScrollWheel") * 10f * factor;

					//destroying the cube and adding it to weapon
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
							//creating new cube
							if((ray.origin - hit.point).magnitude > 4f * factor){
								GameObject cube = (GameObject)Instantiate (prefab, transform.position + transform.forward * 2f * factor , Quaternion.identity);
								go = cube;
								go.transform.localScale *= factor;
								controller.cubes -= 1;
								distance = 3f * factor;
								pick (go);
							}
						}
					}
				}
			}
			//blocking camera
			if (Input.GetKeyDown (KeyCode.Mouse1) && update) {
				if (controller.blockCamera) {
					controller.blockCamera = false;
				} else {
					controller.blockCamera = true;
				}
			}

			//if player is on active cube -> release it
			if(controller.oncube == go && go != null){
				release();
			}
		}
	}
	
	void FixedUpdate(){
		if (controller.hasWeapon) {
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));
			Vector3 pos = ray.origin + Camera.main.transform.forward * distance; //where the cube should be moved
			Vector3 coll = Vector3.zero;
			if (update && go) {
				lr.enabled = true;
				RaycastHit cubeHit;
				if (Physics.Raycast (ray.origin, Camera.main.transform.forward, out cubeHit, 200f, lm)) {
					if (cubeHit.collider.gameObject != go) { // not hitting the active cube 
						RaycastHit hit;
						if (Physics.Raycast (go.transform.position, pos - go.transform.position, out hit, (pos - go.transform.position).magnitude, dp)) {
							coll = (hit.point - go.transform.position); //intersection of the cube's collider and line from cube's position to target position
						}
						if (Physics.Raycast (go.transform.position + coll, (pos - go.transform.position) - coll, out hit, (pos - go.transform.position - coll).magnitude, dp)) {
							pos = hit.point; //target position now is where the cube hits anything on his way
						}
					}
				}

				//adding player velocity
				Vector3 force = pos - go.transform.position;
				rb.velocity = Playermovement.velocity;
				rb.AddForce (force * 1 / (10 * Time.fixedDeltaTime), ForceMode.VelocityChange);
				rb.angularVelocity = Vector3.Lerp (rb.angularVelocity, Vector3.zero, Time.fixedDeltaTime * 10);

				//if camera is blocked vertical mousemovement rotates the cube
				if (controller.blockCamera) {
					if(!rotating.isPlaying){
						rotating.Play();
					}
					if(controller.slow){
						rb.AddTorque (0f, -Input.GetAxis ("Mouse X") * factor, 0f);
					}else{
						rb.AddTorque (0f, -Input.GetAxis ("Mouse X") * 10f * factor, 0f);
					}
				}
				lr.SetPosition (1, go.transform.position); //weapon laser end point set to active cube
			}else lr.enabled = false;
		}
	}

	//picks the cube (if small only small cubes can be picked)
	void pick(GameObject g){
		if ((controller.small && g.transform.localScale.y < 1f) || (!controller.small && g.transform.localScale.y == 1f)) {
			go = g;
			foreach (BoxCollider col in go.GetComponents<BoxCollider> ()) {
				if (col.isTrigger) {
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
	}

	//reverse pick()
	void release(){
		Trigger.enabled = true;
		Trigger = null;
		
		update = false;
		
		rb.useGravity = true;
		rb = null;
		go = null;

		controller.blockCamera = false;
	}

	public void stop(GameObject g){
		if (g == go) {
			release();
		}
	}
}

