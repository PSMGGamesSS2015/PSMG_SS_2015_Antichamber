using UnityEngine;
using System.Collections;

//rotating the camera vertically
public class CameraScript : MonoBehaviour {

	float mouseSensitivity = 2f; //mouse sensitivy
	float max = 280; // maximal rotation angle
	float min = 80; // minimal rotation angle

	// rotating the camera vertically depending on vertical mousemovement
	void Update () {
		if (!controller.blockCamera) {
			float inp = -Input.GetAxis ("Mouse Y") * mouseSensitivity;
			float x = transform.localEulerAngles.x;
			if (x > max || x < min) {
				transform.Rotate (inp, 0, 0);
			} else {
				if (x < max && x > 180f && inp > 0) {
					transform.Rotate (inp, 0, 0);
				}
				if (x > min && x < 180f && inp < 0) {
					transform.Rotate (inp, 0, 0);
				}
			}
		}
	}
}
