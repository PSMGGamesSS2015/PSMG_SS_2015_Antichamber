using UnityEngine;
using System.Collections;

public class Endlessstairs : MonoBehaviour {
	Vector3 stepSize = new Vector3 (0f, -0.2f, 0.5f);
	bool hit = false;

	//endless stairs at level 1
	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") {
			controller.player.transform.position += stepSize;
			if(!hit){
				hit = true;
				controller.level2();
			}
		}
	}
}
