using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	int portal_id = 0;
	Vector3 portal_start = Vector3.zero;
	// Use this for initialization
	void Start () {
		if (gameObject.name == "Portal1") {
			portal_id = Statics.LEVEL2_FIRSTPORTAL;
			getStart();
		}
		if (gameObject.name == "Portal2") {
			portal_id = Statics.LEVEL2_SECONDPORTAL;
			getStart();
		}
		if (gameObject.name == "Portal3") {
			portal_id = Statics.LEVEL5_PORTAL;
			getStart();
		}
		if (gameObject.name == "PortalB") {
			portal_id = Statics.LEVELB;
			getStart();
		}
		if (gameObject.name == "Portal7") {
			portal_id = Statics.LEVEL7;
			getStart();
		}
		if (gameObject.name == "Portal8") {
			portal_id = Statics.LEVEL8;
			getStart();
		}
	}
	
	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") {
			controller.teleport(portal_id, portal_start);
		}
	}

	void getStart(){
		foreach(Transform t in gameObject.GetComponentInChildren<Transform>()){
			if(t.tag == "Start"){
				portal_start = t.position;
			}
		}
	}
}
