using UnityEngine;
using System.Collections;

public class CubeReseter : MonoBehaviour {

	//this script resets a cube/lasercube to its origin and destroys all cubes in the player's weapon
	void OnTriggerEnter (Collider col) {
		if (col.tag == "Lasercube") {
			GameObject cube = col.gameObject;
			CubeScript cs = cube.GetComponent<CubeScript>();
			cube.transform.position = cs.start;
			cube.transform.rotation = cs.rot;
		}
		if (col.tag == "Cube") {
			GameObject cube = col.gameObject;
			CubeScript cs = cube.GetComponent<CubeScript> ();
			Instantiate (weapon.prefab, cs.start, cs.rot);
			controller.player.GetComponent<weapon>().stop(cube);
			controller.player.GetComponent<Cubepicker>().stop(cube);
			Destroy (cube);
		}
		if (col.tag == "Player") {	
			controller.cubes = 0;
		}
	}
}
