using UnityEngine;
using System.Collections;

public class Aufzugscript : MonoBehaviour {
	bool entered = false;
	int portal_id = 0;
	Vector3 portal_start = Vector3.zero;
	// Use this for initialization
	void Start () {
		if (gameObject.name == "Aufzug9") {
			portal_id = Statics.LEVEL9_AUFZUG;
			getStart();
		}
		if (gameObject.name == "Aufzug10") {
			portal_id = Statics.LEVEL10_AUFZUG;
			getStart();
		}
		if (gameObject.name == "Aufzug14") {
			portal_id = Statics.LEVEL14_AUFZUG;
			getStart();
		}
		if (gameObject.name == "Aufzug15") {
			portal_id = Statics.LEVEL15_AUFZUG;
			getStart();
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player" && !col.isTrigger && !entered) {
			controller.sound (GetComponent<AudioSource>());
			entered = true;
			Dooranimator da = transform.parent.gameObject.GetComponent<Dooranimator> ();
			da.openable = false;
			da.close ();             
			StartCoroutine (wait());
		}
	}

	void getStart(){
		foreach(Transform t in gameObject.transform.parent.gameObject.GetComponentInChildren<Transform>()){
			if(t.tag == "Start"){
				portal_start = t.position;
			}
		}
	}
		
	IEnumerator wait(){
		yield return new WaitForSeconds(3.0f);
		controller.teleport(portal_id, portal_start);
	}
}
