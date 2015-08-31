using UnityEngine;
using System.Collections;

public class Mask : MonoBehaviour {

	bool press = false;


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

	void OnTriggerStay(Collider col){
		UIScript.showMask = true;
		if (col.tag == "Player" && !col.isTrigger) {
			press = true;

		}
	}

	void OnTriggerExit(Collider col){
		UIScript.showMask = false;
		if (col.tag == "Player" && !col.isTrigger) {
			press = false;
		}
	}


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
