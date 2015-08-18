using UnityEngine;
using System.Collections;

public class Statics : MonoBehaviour {
	public const int LEVEL2_FIRSTPORTAL = 1;
	public const int LEVEL2_SECONDPORTAL = 2;
	public const int LEVEL5_PORTAL = 3;
	public const int LEVEL7 = 4;
	public const int LEVEL8 = 5;
	public const int LEVELB = 9;
	public static GameObject lvl2;
	public static Vector3 lvl2_start;
	public static Vector3 lvl5_start;
	public static Vector3 lvl7_start;
	public static Vector3 lvl8_start;
	public static Vector3 lvlB_start;
	public static GameObject lvl5_cube;

	void Start(){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Start")) {
			if(go.transform.parent.tag == "Level 2"){
				lvl2 = go.transform.parent.gameObject;
				lvl2_start = go.transform.position;
			}
			if(go.transform.parent.tag == "Level 5"){
				lvl5_start = go.transform.position;
			}
			if(go.transform.parent.tag == "Level 14"){
				lvlB_start = go.transform.position;
			}
			if(go.transform.parent.tag == "Level 7"){
				lvl7_start = go.transform.position;
			}
			if(go.transform.parent.tag == "Level 8"){
				lvl8_start = go.transform.position;
			}
		}
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Reset")) {
			if(go.transform.parent.tag == "Level 5"){
				foreach(Transform cube in go.GetComponentsInChildren<Transform>()){
					lvl5_cube = cube.gameObject;
				}
			}
		}
	}
}
