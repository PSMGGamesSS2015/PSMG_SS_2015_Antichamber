using UnityEngine;
using System.Collections;

public class CubeInteraction : MonoBehaviour {

	public static bool interact = false;
	public static bool releaseable = false;
	GameObject cube;

	void Start () {

	}

	void Update(){
		if (releaseable) {
			if(Input.GetKeyDown(KeyCode.E)){
				releaseable = false;
				cube.GetComponent<Rigidbody>().isKinematic = false;
				cube.transform.parent = null;
			}
		}
		if (interact) {
			if(Input.GetKeyDown(KeyCode.E)){
				releaseable = true;
				interact = false;
				cube.GetComponent<Rigidbody>().isKinematic = true;
				cube.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
				cube.transform.Translate(new Vector3(0f, 0.4f, 0f), Space.World);
			}
		}
	}

	void OnTriggerStay(Collider other) {

		if (other.gameObject.tag == "Cube" && !releaseable) {
			interact = true;
			cube = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		
		if (other.gameObject.tag == "Cube" && !releaseable) {
			interact = false;
			cube = null;
		}
	}
}

