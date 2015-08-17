using UnityEngine;
using System.Collections;

public class Dooranimator : MonoBehaviour {
	Animation[] doors;
	bool opened = false;
	bool openable = true;

	// Use this for initialization
	void Start () {
		doors = gameObject.GetComponentsInChildren<Animation> ();
		if (tag == "Finaldoor") {
			openable = false;
			opened = true;
			foreach(Animation animation in doors){
				animation.Play("open");
			}
		}
	}
	
	// Update is called once per frame
	public void open () {
		foreach(Animation animation in doors){
			if(!animation.isPlaying && openable){
				animation.Play("open");
				opened = true;
			}
		}
	}
	public void close () {
		foreach(Animation animation in doors){
			if(!animation.isPlaying){
				animation.Play("close");
				opened = false;
			}
		}
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Player" && !col.isTrigger) {
			if(!opened){
				open ();
			}
		}
	}
	
	void OnTriggerExit(Collider col){
		if (col.tag == "Player" && !col.isTrigger) {
			if(opened){
				close ();
			}
		}
	}
}
