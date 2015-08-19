using UnityEngine;
using System.Collections;

public class Laserscript : MonoBehaviour {
	LineRenderer lr;
	Vector3 pos1;
	RaycastHit hit;
	GameObject hitCube;
	LayerMask lm;

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
		pos1 = gameObject.transform.position;
		lr.SetPosition (0, pos1);
		lm = 1 << LayerMask.NameToLayer ("Doorportal");
		lm = ~lm;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (transform.position, transform.position + transform.forward);
		if (Physics.Raycast (pos1, transform.right * (-1), out hit, 200.0f, lm)) {
			lr.SetPosition (1, hit.point);
			if (hit.collider.gameObject.tag == "Lasercube") {
				Lasercube lc;
				if (hitCube != null && hitCube != hit.collider.gameObject) {
					lc = hitCube.GetComponent<Lasercube> ();
					lc.stop ();
				}
				hitCube = hit.collider.gameObject;
				lc = hitCube.GetComponent<Lasercube> ();
				if (lc != null) {
					lc.shoot = true;
				}
			} else {
				if (hitCube != null) {
					Lasercube lc = hitCube.GetComponent<Lasercube> ();
					if (lc != null) {
						lc.stop ();
					}
					hitCube = null;
				}
			}
		} else {
			lr.SetPosition(1, pos1 + transform.right * (-1) * 200.0f);
			if (hitCube != null) {
				Lasercube lc = hitCube.GetComponent<Lasercube> ();
				if (lc != null) {
					lc.stop ();
				}
				hitCube = null;
			}
		}
	}
}
