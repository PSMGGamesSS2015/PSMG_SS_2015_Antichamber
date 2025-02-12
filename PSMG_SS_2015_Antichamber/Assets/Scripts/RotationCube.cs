﻿using UnityEngine;
using System.Collections;

public class RotationCube : MonoBehaviour {
	bool ok = false;

	// Update is called once per frame
	void Update () {
		float rot = transform.rotation.eulerAngles.y;
		if (rot > 110f && rot < 190f) {
			if(!ok){
				ok = true;
				if(gameObject.transform.parent.name == "Level 9") { //transforms level 9 if the rotation is done
					Destroy(GameObject.FindGameObjectWithTag("Level9 Floor"));
					foreach(Transform go in GameObject.FindGameObjectWithTag("Level9 Stairs").GetComponentInChildren<Transform>()){
						go.gameObject.layer = LayerMask.NameToLayer("Default");
					}
				}else if(gameObject.transform.parent.name == "Level I") {//rotates the final cube if the rotation is done
					GameObject finalcube = GameObject.FindWithTag("finalcube");
					controller.player.transform.parent = finalcube.transform;
					finalcube.transform.Rotate(Vector3.forward*180f);
					controller.player.transform.parent = null;
				}
			}
		}
	}

	void FixedUpdate(){ //rotating the cylinder when the ratation cubes is rotated
		if (gameObject.name == "Rotator") {
			foreach(Transform t in gameObject.transform.parent.GetComponentInChildren<Transform>()){
				if(t.tag == "Rotator"){
					t.Rotate(Vector3.forward * gameObject.GetComponent<Rigidbody>().angularVelocity.y * 0.1f);
				}
			}
		}
	}
}
