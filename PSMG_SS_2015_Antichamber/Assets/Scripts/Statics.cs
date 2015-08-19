using UnityEngine;
using System.Collections;

public class Statics : MonoBehaviour {
	public const int LEVEL2_FIRSTPORTAL = 1;
	public const int LEVEL2_SECONDPORTAL = 2;
	public const int LEVEL5_PORTAL = 3;
	public const int LEVEL7 = 4;
	public const int LEVEL8 = 5;
	public const int LEVEL9 = 6;
	public const int LEVEL9_AUFZUG = 7;
	public const int LEVEL10_AUFZUG = 8;
	public const int LEVEL11_AUFZUG = 9;
	public const int LEVEL12_PORTAL = 10;
	public const int LEVEL14_AUFZUG = 11;
	public const int LEVELB = 12;
	public const int LEVEL15_AUFZUG = 13;
	public const int LEVELS1_PORTAL = 14;
	public const int LEVELBACK1_PORTAL = 15;
	public const int LEVELS2_PORTAL = 16;
	public const int LEVEL17_PORTAL = 17;
	public static GameObject lvl2;
	public static Vector3 lvl2_start;
	public static Vector3 lvl5_start;
	public static Vector3 lvl7_start;
	public static Vector3 lvl8_start;
	public static Vector3 lvl9_start;
	public static Vector3 lvl10_aufzug;
	public static Vector3 lvl11_aufzug;
	public static Vector3 lvl11_start;
	public static Vector3 lvl12_start;
	public static Vector3 lvl13_start;
	public static Vector3 lvl15_start;
	public static Vector3 lvl16_start;
	public static Vector3 lvlB_start;
	public static Vector3 lvlS1_start;
	public static Vector3 lvlS2_start;
	public static Vector3 lvlG_start;
	public static Vector3 lvl17_start;
	public static GameObject lvl5_cube;
	public static GameObject LEVEL8_PORTAL; //Teleportscript
	public static GameObject LEVEL9_PORTAL;

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
			if(go.transform.parent.tag == "Level 9"){
				lvl9_start = go.transform.position;
			}
			if(go.transform.parent.name == "Aufzug10"){
				lvl10_aufzug = go.transform.position;
			}
			if(go.transform.parent.name == "Aufzug11"){
				lvl11_start = go.transform.position;
			}
			if(go.transform.parent.name == "Level 12"){
				lvl12_start = go.transform.position;
			}
			if(go.transform.parent.name == "Level 13"){
				lvl13_start = go.transform.position;
			}
			if(go.transform.parent.name == "Level 15"){
				lvl15_start = go.transform.position;
			}
			if(go.transform.parent.name == "Level 16"){
				lvl16_start = go.transform.position;
			}
			if(go.transform.parent.name == "Level S1"){
				lvlS1_start = go.transform.position;
			}
			if(go.transform.parent.name == "Level S2"){
				lvlS2_start = go.transform.position;
			}
			if(go.transform.parent.name == "Level G"){
				lvlG_start = go.transform.position;
			}
			if(go.transform.parent.name == "Level 17"){
				lvl17_start = go.transform.position;
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
