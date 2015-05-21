using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public static float cameraspeed = 2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(-Input.GetAxis ("Mouse Y")*cameraspeed,0f, 0f); //rotating the camera
	}
}
