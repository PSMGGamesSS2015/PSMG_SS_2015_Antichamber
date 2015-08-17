using UnityEngine;
using System.Collections;

public class Statics : MonoBehaviour {
	public const int LEVEL2_FIRSTPORTAL = 1;
	public const int LEVEL2_SECONDPORTAL = 2;
	public const int LEVEL5_PORTAL = 3;
	public const int LEVELB = 9;
	public static GameObject lvl2;
	public static Vector3 lvl2_start;
	public static Vector3 lvl5_start;
	public static Vector3 lvlB_start;

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
		}
	}
}
