using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {
	public static bool showMask = false;
	Image mask;
	RectTransform[] elements;

	// Use this for initialization
	void Start () {
		elements = GetComponentsInChildren<RectTransform> ();
		foreach (RectTransform tf in elements) {
			if (tf.gameObject.name == "Mask") {
				mask = tf.gameObject.GetComponent<Image> ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (showMask) {
			mask.enabled = true;
		} else mask.enabled = false;
	}
}
