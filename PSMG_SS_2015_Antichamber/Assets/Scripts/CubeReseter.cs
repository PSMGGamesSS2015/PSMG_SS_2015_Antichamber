using UnityEngine;
using System.Collections;

public class CubeReseter : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Cube" || col.tag == "Lasercube") {
			GameObject cube = col.gameObject;
			CubeScript cs = cube.GetComponent<CubeScript>();
			cube.transform.position = cs.start;
			cube.transform.rotation = cs.rot;
		}
		if (col.tag == "Player") {	
			controller.cubes = 0;
		}
	}
}
