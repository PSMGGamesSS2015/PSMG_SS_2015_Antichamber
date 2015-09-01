using UnityEngine;
using System.Collections;

public class Dooranimator : MonoBehaviour {
	Animation[] doors; //left and right side animation
	bool opened = false; //door opened
	public bool openable = true; //is it openable?

	// Use this for initialization
	void  OnEnable () {
		doors = gameObject.GetComponentsInChildren<Animation> ();
		if (tag == "Finaldoor") { //these doors are initially opened and can't be reopened after closing
			openable = false;
			opened = true;
			foreach(Animation animation in doors){
				animation.Play("open");
			}
		}
	}
	
	// opening a door
	public void open () {
		foreach(Animation animation in doors){
			if(!animation.isPlaying && openable){
				animation.Play("open");
				opened = true;
			}
		}
	}

	//closing a door
	public void close () {
		foreach(Animation animation in doors){
			if(!animation.isPlaying){
				animation.Play("close");
				opened = false;
			}
		}
	}

	void OnTriggerStay(Collider col){
		if (tag == "Triggerdoor") { //opens if cube is on the trigger
			if (col.tag == "Cube" && !opened) {
				open ();
			}
		}
		else if ((col.tag == "Player" && !col.isTrigger) || col.gameObject.name == "Verwandlung") {
			if(tag == "Backwards"){ //only opening if player runs through backwards
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
		else if ((col.tag == "Player" && !col.isTrigger) || col.gameObject.name == "Verwandlung") {
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
