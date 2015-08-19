using UnityEngine;
using System.Collections;

public class Lasercube : MonoBehaviour {
	public bool shoot = false;
	LineRenderer lr;
	GameObject hitCube;
	LayerMask lm;

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
		lm = 1 << LayerMask.NameToLayer ("Doorportal") | 1 << LayerMask.NameToLayer("Ignore Raycast");
		lm = ~lm; //reverse
	}

	void FixedUpdate () {
		if (!shoot) {
			lr.enabled = false;
			if (hitCube != null) {
				Lasercube lc = hitCube.GetComponent<Lasercube> ();
				lc.stop ();
				hitCube = null;
			}
		} else{
			shootLaser ();
		}
	}

	void shootLaser(){
		lr.enabled = true;
		Vector3 pos1;
		RaycastHit hit;
		pos1 = transform.position;
		lr.SetPosition (0, pos1);
		if (Physics.Raycast (pos1, transform.forward, out hit,200f, lm)) {
			lr.SetPosition (1, hit.point);
			Debug.DrawLine(pos1, hit.point);
			if (hit.collider.gameObject.tag == "Lasercube") {
				Lasercube lc;
				if(hitCube != null && hitCube != hit.collider.gameObject){
					lc = hitCube.GetComponent<Lasercube> ();
					lc.stop ();
				}
				hitCube = hit.collider.gameObject;
				lc = hitCube.GetComponent<Lasercube> ();
				if(lc != null && !lc.shoot){
					lc.shoot = true;
				}
			} else {
				if (hitCube != null) {
					Lasercube lc = hitCube.GetComponent<Lasercube> ();
					if(lc != null){
						lc.stop();
					}
					hitCube = null;
				}
			}
			if(hit.collider.gameObject.tag == "Lasergoal"){
				controller.laser += 1;
				Destroy(hit.collider);
				controller.lasergoal(hit.collider.gameObject);
			}
		} else {
			lr.SetPosition(1, transform.position + transform.forward * 200.0f);
			if (hitCube != null) {
				Lasercube lc = hitCube.GetComponent<Lasercube> ();
				if (lc != null) {
					lc.stop ();
				}
				hitCube = null;
			}
		}
	}

	public void stop(){
		shoot = false;
	}
}
