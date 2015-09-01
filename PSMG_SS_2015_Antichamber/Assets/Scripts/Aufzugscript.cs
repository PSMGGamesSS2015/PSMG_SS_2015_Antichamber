using UnityEngine;
using System.Collections;

//This script teleports the player to the next level

public class Aufzugscript : MonoBehaviour {
	bool entered = false; //has the player entered the elevator?
	int portal_id = 0; //id for the teleport (controllerscript)
	Vector3 portal_start = Vector3.zero; //position of the teleport origin

	// Gets the right data(portal ID and Teleport origin) for each gameobject
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

	//if the player enters the elevator the teleport starts
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player" && !col.isTrigger && !entered) {
			entered = true;
			Dooranimator da = transform.parent.gameObject.GetComponent<Dooranimator> (); //getting the elevator's dooranimatiorscript
			da.openable = false; //elevator door must stay closed while teleporting
			da.close (); //closing the elevator door
			StartCoroutine (wait()); //teleporting after 3 seconds
		}
	}

	//getting the teleport origin (empty with tag "Start")
	void getStart(){
		foreach(Transform t in gameObject.transform.parent.gameObject.GetComponentInChildren<Transform>()){
			if(t.tag == "Start"){
				portal_start = t.position;
			}
		}
	}

	//teleporting after 3 seconds	
	IEnumerator wait(){
		yield return new WaitForSeconds(3.0f);
		controller.teleport(portal_id, portal_start);
	}
}
