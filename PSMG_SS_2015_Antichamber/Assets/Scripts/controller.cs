using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	public static bool slow = false;
	public static GameObject player;
	public static bool blockCamera = false;
	public static int cubes = 0;
	public static bool hasWeapon = false;
	public static int laser = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

	}

	public static void level2(){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag ("Level 1")) {
			Destroy (go);
		}
		foreach (Transform go in Statics.lvl2.GetComponentsInChildren<Transform>()) {
			go.gameObject.layer = LayerMask.NameToLayer("Default");
		}
	}

	public static void teleport(int PORTAL_ID, Vector3 portal_start){
		Vector3 portvector;
		float rotationVal = 0f;
		Vector3 rot;
		Vector3 diff = player.transform.position - portal_start;
		diff.y = 0;
		switch (PORTAL_ID) {
		case Statics.LEVEL2_FIRSTPORTAL:
			portvector = Statics.lvl2_start - portal_start;
			rotationVal = 90f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (90f, Vector3.up) * diff;
			break;
		case Statics.LEVEL2_SECONDPORTAL:
			portvector = Statics.lvl2_start - portal_start;
			rotationVal = 90f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		case Statics.LEVEL5_PORTAL:
			portvector = Statics.lvl5_start - portal_start;
			rotationVal = 90f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		case Statics.LEVELB:
			portvector = Statics.lvlB_start - portal_start;
			rotationVal = 180f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		default:
			portvector = Vector3.zero;
			rot = Vector3.zero;
			diff = Vector3.zero;
			break;
		}
		player.transform.Rotate(rot);
		Vector3 velocity = player.GetComponent<Rigidbody> ().velocity;
		velocity = Quaternion.AngleAxis (rotationVal, Vector3.up) * velocity;
		player.GetComponent<Rigidbody> ().velocity = velocity;
		player.transform.position += portvector;
		player.transform.position -= diff;
	}
}
