using UnityEngine;
using System.Collections;

public class retsel : MonoBehaviour {
	bool ok = false;

	void OnTriggerStay(Collider col){
		if (col.gameObject.name == gameObject.name) {
			if(!ok){
				ok = true;
				controller.retsel +=1;
			}
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.name == gameObject.name) {
			ok = false;
			controller.retsel -=1;
		}
	}
}
