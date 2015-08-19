using UnityEngine;
using System.Collections;

public class playerreset : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			controller.player.transform.position = transform.position;
		}
	}
}
