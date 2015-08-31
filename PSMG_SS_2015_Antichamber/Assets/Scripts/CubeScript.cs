using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {
	
	Rigidbody rb;
	public Vector3 start;
	public Quaternion rot;
	float distanceToGround = 1f;
	LayerMask lm;
	// Use this for initialization
	void Start () {
		start = transform.position;
		rot = transform.rotation;
		rb = GetComponent<Rigidbody> ();
		lm = 1 << LayerMask.NameToLayer ("Doorportal") | 1 << LayerMask.NameToLayer ("Inactive");
		lm = ~lm;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		reposition ();
	}
	
	void OnTriggerEnter(Collider other){
		if (!other.isTrigger && other.gameObject != gameObject) {
			rb.constraints = RigidbodyConstraints.FreezeAll;
			rb.isKinematic = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if (!other.isTrigger) {
			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			rb.isKinematic = false;
		}
	}
	
	void reposition(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, lm)) {
			distanceToGround = hit.distance;
		}
		if (distanceToGround < 0.5f * gameObject.transform.localScale.y) {
			rb.transform.position += new Vector3(0f, 0.5f*gameObject.transform.localScale.y - distanceToGround,0f);
		}
	}
}
