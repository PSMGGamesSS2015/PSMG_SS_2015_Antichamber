using UnityEngine;
using System.Collections;

public class waffenblock : MonoBehaviour {

	//playing sound if weapon/mask getts picked up and notifies controller
	void OnCollisionEnter (Collision col) {
		if (col.collider.tag == "Player") {
			transform.parent.gameObject.GetComponent<AudioSource>().Play();
			if(gameObject.name == "Waffe"){
				controller.portalcam.enabled = true;
				Statics.LEVEL9_PORTAL.layer = LayerMask.NameToLayer("Default");
				GameObject.FindGameObjectWithTag("Stencil").layer = LayerMask.NameToLayer("Doorportal");
				controller.hasWeapon = true;
				controller.weaponcam.enabled = true;
			}
			else if (gameObject.name == "Mask") {
				controller.hasMask = true;
				controller.portalcam.enabled = true;
			}
			Destroy(gameObject);
		}
	}
}
