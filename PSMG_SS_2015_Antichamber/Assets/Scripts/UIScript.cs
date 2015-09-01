using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {
	public static bool showMask = false;
	Image mask; //mask icon
	RectTransform[] elements;
	Text cubes; //# cube in weapon

	// Use this for initialization
	void Start () {
		elements = GetComponentsInChildren<RectTransform> ();
		foreach (RectTransform tf in elements) {
			if (tf.gameObject.name == "Mask") {
				mask = tf.gameObject.GetComponent<Image> ();
			}
			if(tf.gameObject.name == "Text"){
				cubes = tf.gameObject.GetComponent<Text>();
				cubes.enabled = false;
			}
		}
		controller.weaponcam = GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (showMask) {
			mask.enabled = true;
		} else mask.enabled = false;
		if (controller.hasWeapon) {
			cubes.enabled = true;
			cubes.text = "" + controller.cubes;
		}
	}
}
