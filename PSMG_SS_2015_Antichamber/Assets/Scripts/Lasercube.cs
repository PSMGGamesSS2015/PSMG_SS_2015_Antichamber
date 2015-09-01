using UnityEngine;
using System.Collections;

public class Lasercube : MonoBehaviour {
	public bool shoot = false; //is the lasercube shooting?
	LineRenderer lr;
	GameObject hitCube; // the cube hit by this cube
	LayerMask lm;
	AudioSource audi;//lasersound

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
		lm = 1 << LayerMask.NameToLayer ("Doorportal") | 1 << LayerMask.NameToLayer("Ignore Raycast"); 
		lm = ~lm; //raycasts using this layermask now ignore "Doorportal" and "Ignore Raycast" layer
		audi = GetComponents<AudioSource> () [1];
	}
	
	void FixedUpdate () {
		if (!shoot) {//stops if not hit by laser anymore
			lr.enabled = false;
			if (hitCube != null) {
				Lasercube lc = hitCube.GetComponent<Lasercube> ();
				lc.stop ();
				hitCube = null;
			}
		} else{ //shoots if hit by laser
			shootLaser ();
		}
	}

	void shootLaser(){
		if(!audi.isPlaying){
			audi.Play ();
		}
		lr.enabled = true;
		Vector3 pos1;
		RaycastHit hit;
		pos1 = transform.position;
		lr.SetPosition (0, pos1); //lasers start position is the lasercubes position
		if (Physics.Raycast (pos1, transform.forward, out hit,200f, lm)) {
			lr.SetPosition (1, hit.point);//lasers end is hitpoint
			/*if lasercube gets hit: make it shoot if it isn't shooting yet
			 *if hit lasercube isn't hit anymore: make it stop 
			 *if hit target: controllers laser count +1
			 */
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
		} else { // nothing is hit -> shoot the laser 200 forward
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
		audi.Stop ();
		shoot = false;
	}
}
