using UnityEngine;
using System.Collections;

public class Dooranimator : MonoBehaviour {
	Animation[] doors;
	bool opened = false;
	public bool openable = true;

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
		if (tag == "Triggerdoor") {
			if (col.tag == "Cube" && !opened) {
				open ();
			}
		}
		else if (col.tag == "Player" && !col.isTrigger) {
			if(tag == "Backwards"){
				float rotation = controller.player.transform.rotation.eulerAngles.y;
				if(rotation > 130f && rotation < 230f){
					if(!opened){
						open ();
					}
				}else {
					if(opened){
						close ();
					}
				}
			}else if(!opened){
				open ();
			}
		}
	}
	
	void OnTriggerExit(Collider col){
		if (tag == "Triggerdoor") {
			if (col.tag == "Cube" && opened) {
				close ();
			}
			if (col.tag == "Player" && !col.isTrigger) {
				if(opened){
					openable = false;
					close ();
				}
			}
		}
		else if (col.tag == "Player" && !col.isTrigger) {
			if(tag == "Backwards"){
				openable = false;
				if(opened){
					close ();
				}
			}else if(opened){
				close ();
			}
		}
	}
}
