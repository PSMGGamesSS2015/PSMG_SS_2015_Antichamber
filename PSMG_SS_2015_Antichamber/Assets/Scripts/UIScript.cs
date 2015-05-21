using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//shows "Press E to pick" if the player can pick up a cube
		if (PickTrigger.interact) {
			text.text = "Press E to pick";
			text.enabled = true;
			return;
		}
		//shows "Press E to release" if the player can release up a cube
		if (PickTrigger.releasable) {
			text.text = "Press E to release";
			text.enabled = true;
			return;
		}
		text.enabled = false;
	}
}
