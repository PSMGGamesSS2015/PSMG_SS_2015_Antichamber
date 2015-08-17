using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject cam;
	float mouseSensitivity = 2f;
	float max = 280;
	float min = 80;

	// Use this for initialization
	void Start () {
		cam = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (!controller.blockCamera) {
			float inp = -Input.GetAxis ("Mouse Y") * mouseSensitivity;
			float x = cam.transform.localEulerAngles.x;
			if (x > max || x < min) {
				cam.transform.Rotate (inp, 0, 0);
			} else {
				if (x < max && x > 180f && inp > 0) {
					cam.transform.Rotate (inp, 0, 0);
				}
				if (x > min && x < 180f && inp < 0) {
					cam.transform.Rotate (inp, 0, 0);
				}
			}
		}
	}
}
