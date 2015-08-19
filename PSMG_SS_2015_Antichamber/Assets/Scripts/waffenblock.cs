using UnityEngine;
using System.Collections;

public class waffenblock : MonoBehaviour {

	void OnCollisionEnter (Collision col) {
		if (col.collider.tag == "Player") {
			if(gameObject.name == "Waffe_Cube"){
				controller.portalcam.enabled = true;
				Statics.LEVEL9_PORTAL.layer = LayerMask.NameToLayer("Default");
				GameObject.FindGameObjectWithTag("Stencil").layer = LayerMask.NameToLayer("Doorportal");
				controller.hasWeapon = true;
			}
		}
		else if (gameObject.name == "Mask") {
			controller.hasMask = true;
			controller.portalcam.enabled = true;
		}
	}
}
