using UnityEngine;
using System.Collections;

//teleporting the player if the specific trigger is entered (controllerscript)
public class Teleport : MonoBehaviour {
	int portal_id = 0;
	Vector3 portal_start = Vector3.zero;
	// Use this for initialization
	void  OnEnable ()  {
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
			Statics.LEVEL8_PORTAL = gameObject;
			getStart();
		}
		if (gameObject.name == "Portal9") {
			portal_id = Statics.LEVEL9;
			Statics.LEVEL9_PORTAL = gameObject;
			getStart();
		}
		if (gameObject.name == "Aufzug12") {
			portal_id = Statics.LEVEL11_AUFZUG;
			getStart();
		}
		if (gameObject.name == "Portal13") {
			portal_id = Statics.LEVEL12_PORTAL;
			getStart();
		}
		if (gameObject.name == "Portal17") {
			portal_id = Statics.LEVEL17_PORTAL;
			getStart();
		}
		if (gameObject.name == "PortalS1") {
			portal_id = Statics.LEVELS1_PORTAL;
			getStart();
		}
		if (gameObject.name == "PortalBack1") {
			portal_id = Statics.LEVELBACK1_PORTAL;
			getStart();
		}
		if (gameObject.name == "PortalS1") {
			portal_id = Statics.LEVELS1_PORTAL;
			getStart();
		}
	}
	
	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") {
			if(tag == "Small"){
				if(controller.small){
					controller.teleport(portal_id, portal_start);
				}
			}else {
				controller.teleport(portal_id, portal_start);
			}
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
