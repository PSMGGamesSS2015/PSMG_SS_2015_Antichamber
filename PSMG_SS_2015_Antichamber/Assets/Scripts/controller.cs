using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	public static bool slow = false;
	public static GameObject player;
	public static bool blockCamera = false;
	public static int cubes = 0;
	public static bool hasWeapon = false;
	public static bool hasMask = false;
	public static bool small = false;
	public static int laser = 0;
	public static Camera portalcam;
	public static int retsel = 0;
	bool solved = false;
	public static AudioSource[] background;
	static bool play = false;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		foreach(Camera cam in player.GetComponentsInChildren<Camera>()){
			if(!(cam.tag == "Main Camera")){
				portalcam = cam;
			}
		}
		portalcam.enabled = false;
		background = GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (retsel == 4 && !solved) {
			solved = true;
			Destroy(GameObject.FindGameObjectWithTag("Level15 Floor"));
			foreach(Transform tf in GameObject.FindGameObjectWithTag("Level15 Stairs").GetComponentInChildren<Transform>()){
				foreach(Transform go in tf){
					go.gameObject.layer = LayerMask.NameToLayer("Default");
				}
			}
		}
		if (play) {
			play = false;
			StartCoroutine (playbackgound ());
		}
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
			GameObject cube = Statics.lvl5_cube;
			CubeScript cs = cube.GetComponent<CubeScript>();
			cube.transform.position = cs.start;
			cube.transform.rotation = cs.rot;
			break;
		case Statics.LEVELB:
			portvector = Statics.lvlB_start - portal_start;
			rotationVal = 180f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		case Statics.LEVEL7:
			portvector = Statics.lvl7_start - portal_start;
			rotationVal = 180f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		case Statics.LEVEL8:
			portvector = Statics.lvl8_start - portal_start;
			rotationVal = 180f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			portalcam.enabled = false;
			Destroy(Statics.LEVEL8_PORTAL);
			break;
		case Statics.LEVEL9:
			portvector = Statics.lvl9_start - portal_start;
			rotationVal = -20f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			portalcam.enabled = false;
			break;
		case Statics.LEVEL9_AUFZUG:
			portvector = Statics.lvl10_aufzug - portal_start;
			rotationVal = 70f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		case Statics.LEVEL10_AUFZUG:
			portvector = Statics.lvl11_start - portal_start;
			rotationVal = 0f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		case Statics.LEVEL11_AUFZUG:
			portvector = Statics.lvl12_start - portal_start;
			rotationVal = 90f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		case Statics.LEVEL12_PORTAL:
			portvector = Statics.lvl13_start - portal_start;
			rotationVal = 0f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			portalcam.enabled = false;
			break;
		case Statics.LEVEL14_AUFZUG:
			portvector = Statics.lvl15_start - portal_start;
			rotationVal = 180f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		case Statics.LEVEL15_AUFZUG:
			portvector = Statics.lvl16_start - portal_start;
			rotationVal = 180f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			portalcam.enabled = true;
			break;
		case Statics.LEVELS1_PORTAL:
			portvector = Statics.lvlS1_start - portal_start;
			rotationVal = -70f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		case Statics.LEVELBACK1_PORTAL:
			portvector = Statics.lvlG_start - portal_start;
			rotationVal = 70f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			break;
		case Statics.LEVEL17_PORTAL:
			portvector = Statics.lvl17_start - portal_start;
			rotationVal = 180f;
			rot = new Vector3(0f, rotationVal, 0f);
			diff -= Quaternion.AngleAxis (rotationVal, Vector3.up) * diff;
			portalcam.enabled = false;
			break;
		case Statics.LEVELS2_PORTAL:
			portvector = Statics.lvlS2_start - portal_start;
			rotationVal = -90f;
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

	public static void lasergoal(GameObject goal){
		if (laser != 2 && laser != 4) {
			goal.GetComponent<Animation> ().Play ("Doorup");
			portalcam.enabled = true;
		} else if (laser == 4) {
			Destroy (goal);
		}
	}

	public static void sound(AudioSource src){
		if(src != null){
			foreach(AudioSource s in controller.background){
				if(s.isPlaying){
					s.Stop();
				}
			}
			src.Play();
			play = true;
		}
	}

	IEnumerator playbackgound(){
		yield return new WaitForSeconds(5.0f);
		background [0].Play ();
	}
}
