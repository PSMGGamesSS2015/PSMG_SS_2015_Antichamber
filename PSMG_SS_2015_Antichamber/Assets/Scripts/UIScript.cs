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
		if (CubeInteraction.interact) {
			text.text = "Press E to pick up";
			text.enabled = true;
			return;
		}
		if (CubeInteraction.releaseable) {
			text.text = "Press E to release";
			text.enabled = true;
			return;
		}
		text.enabled = false;
	}
}
