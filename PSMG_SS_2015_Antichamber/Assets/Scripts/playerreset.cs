﻿using UnityEngine;
using System.Collections;


//resets the player if he falls down
public class playerreset : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			controller.player.transform.position = transform.position;
		}
	}
}
