using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {
	
	Rigidbody rb;
	public Vector3 start; //cubes origin
	public Quaternion rot; //cubes original rotation
	float distanceToGround = 1f; //distance to ground
	LayerMask lm; 
	AudioSource audi;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		rb.isKinematic = false;
	}

	// Use this for initialization
	void Start () {
		start = transform.position;
		rot = transform.rotation;
		rb = GetComponent<Rigidbody> ();
		lm = 1 << LayerMask.NameToLayer ("Doorportal") | 1 << LayerMask.NameToLayer ("Inactive");
		lm = ~lm; //raycasts using this layermask now ignore "Doorportal" and "Inactive" layer
		audi = GetComponents<AudioSource> ()[0];
	}

	//repositioning cube's y value
	void LateUpdate () {
		reposition ();
	}

	//freezing the cube if it's bottom side is colliding with floor/cube
	void OnTriggerEnter(Collider other){
		if (!other.isTrigger && other.gameObject != gameObject) {
			rb.constraints = RigidbodyConstraints.FreezeAll;
			rb.isKinematic = true;
			if(GetComponent<AudioSource>()!=null){
				audi.Play();
			}
		}
	}

	//undoing ontriggerenter
	void OnTriggerExit(Collider other){
		if (!other.isTrigger) {
			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			rb.isKinematic = false;
		}
	}

	//repositioning
	void reposition(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 0.5f, lm)) { //something inside the cube?
			distanceToGround = hit.distance;
		} else {
			distanceToGround = 0.5f;
		}
		if (distanceToGround < 0.5f * gameObject.transform.localScale.y) { 
			rb.transform.position += new Vector3(0f, 0.5f*gameObject.transform.localScale.y - distanceToGround,0f); //pushing the cube up if something is inside
		}
	}
}
