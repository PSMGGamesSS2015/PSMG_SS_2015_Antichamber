using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject cam;

	// Use this for initialization
	void Start () {
		cam = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		cam.transform.Rotate(Input.GetAxis ("Mouse Y")*(-1),0f, 0f);
	}
}
