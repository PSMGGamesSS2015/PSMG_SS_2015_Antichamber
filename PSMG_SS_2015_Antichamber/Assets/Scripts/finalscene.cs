using UnityEngine;
using System.Collections;

public class finalscene : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			controller.player.GetComponent<Animation>().Play ("finalscene");
			controller.weaponcam.enabled = false;
			Camera.main.transform.rotation = Quaternion.identity;
		}
	}
}
