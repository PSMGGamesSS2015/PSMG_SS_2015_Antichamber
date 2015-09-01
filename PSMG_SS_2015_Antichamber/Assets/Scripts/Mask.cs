using UnityEngine;
using System.Collections;

public class Mask : MonoBehaviour {
	bool press = false; //can player press Q?

	void Update(){
		if (Input.GetKeyDown (KeyCode.Q) && controller.hasMask) {
			if (press) {
				if (!controller.small) {
					small ();
				} else {
					big ();
				}
			}
		}
	}

	//player is in a mask area -> show UI
	void OnTriggerStay(Collider col){
		if (col.tag == "Player" && !col.isTrigger) {
			UIScript.showMask = true;
			press = true;
		}
	}

	//player left maks area -> hide UI
	void OnTriggerExit(Collider col){
		if (col.tag == "Player" && !col.isTrigger) {
			UIScript.showMask = false;
			press = false;
		}
	}

	//making player small
	void small(){
		if (!controller.small) {
			controller.small = true;
			controller.player.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			controller.player.GetComponent<Playermovement> ().factor = 0.1f;
			controller.player.GetComponent<Playermovement> ().gravity = 0.981f;
			controller.player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			controller.player.transform.position -= Vector3.up * 0.9f;
		}
	}
	
	//making player big
	void big(){
		if (controller.small) {
			controller.small = false;
			controller.player.transform.localScale = new Vector3 (1f, 1f, 1f);
			controller.player.GetComponent<Playermovement> ().factor = 1f;
			controller.player.GetComponent<Playermovement> ().gravity = 9.81f;
			controller.player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			controller.player.transform.position += Vector3.up * 0.9f;
		}
	}
}
