using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	public static bool slow = false; //is the player moving slow?
	public static GameObject player; //player GameObject
	public static bool blockCamera = false; // blocking camera while rotating a cube
	public static int cubes = 0; // # of cubes in weapon
	public static bool hasWeapon = false; //weapon already taken?
	public static bool hasMask = false; //mask already taken?
	public static bool small = false; //player shrinked with mask?
	public static int laser = 0; //how many lasergoals are hit?
	public static Camera portalcam; //doorportallayer camera
	public static Camera weaponcam; //weaponcamera
	public static int retsel = 0; //# of cubes solved at level 15
	bool solved = false; //level 15 solved?
	public static AudioSource[] background; //backgound music (Array of Audiosource with 2 elements)
	int song = 0; //which song is next?
	public static GameObject oncube; //cube which the player stands on
	public static GameObject menu; //menu

	// Use this for initialization
	void OnEnable () {
		Cursor.visible = false; //setting mouse cursor invisible
		player = GameObject.FindGameObjectWithTag ("Player");
		foreach(Camera cam in player.GetComponentsInChildren<Camera>()){
			if(!(cam.tag == "Main Camera")){
				portalcam = cam;
			}
		}
		portalcam.enabled = false; //disabled until first door portal
		background = GetComponents<AudioSource> ();
		menu = GameObject.FindWithTag ("Menu");
		menu.GetComponent<Canvas> ().enabled = false;
	}
	

	void Update () {
		//Level 15
		if (retsel == 4 && !solved) {
			solved = true;
			Destroy(GameObject.FindGameObjectWithTag("Level15 Floor"));
			foreach(Transform tf in GameObject.FindGameObjectWithTag("Level15 Stairs").GetComponentInChildren<Transform>()){
				foreach(Transform go in tf){
					go.gameObject.layer = LayerMask.NameToLayer("Default");
				}
			}
		}

		//background music
		if (background [0].isPlaying) {
			song = 1;
		} else if (background [1].isPlaying) {
			song = 0;
		} else background [song].Play ();

		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			menu.GetComponent<Canvas>().enabled = true;
			Cursor.visible = true;
		}
	}


	//Destroying level 1; setting the inactive parts of level 2 to active
	public static void level2(){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag ("Level 1")) {
			Destroy (go);
		}
		foreach (Transform go in Statics.lvl2.GetComponentsInChildren<Transform>()) {
			go.gameObject.layer = LayerMask.NameToLayer("Default");
		}
	}


	/*teleporting:  -to next level
	 * 				-to level start
	 */

	public static void teleport(int PORTAL_ID, Vector3 portal_start){
		Vector3 portvector = Vector3.zero;
		float rotationVal = 0f;
		Vector3 rot = Vector3.zero;
		Vector3 diff = player.transform.position - portal_start; //difference between player's position and teleport origin
		diff.y = 0; //player height is one; start height is zero

		/*for the PORTAL ID case do:
		 *  portvector: Vector from teleport origin to teleport goal
		 * 	rotationVal: The y - rotation to be performed with the teleport
		 * 	rot: getting the y - rotation as Vector
		 * 	-> rotating the difference bettween player's position and origin of teleport
		 */

		switch (PORTAL_ID) {
		case 18:
			diff = Vector3.zero;
			player.transform.position = new Vector3(0f,1f,-4f);
			player.transform.rotation = Quaternion.identity;
			break;
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
		velocity = Quaternion.AngleAxis (rotationVal, Vector3.up) * velocity; //rotating the velocity 
		player.GetComponent<Rigidbody> ().velocity = velocity;
		player.transform.position += portvector;
		player.transform.position -= diff;
	}

	public static void lasergoal(GameObject goal){
		if (laser != 2 && laser != 4) { //determining which lasergoal was hit (1:level 6 finsihed; 3: level 12 finished)
			goal.GetComponent<Animation> ().Play ("Doorup");
			portalcam.enabled = true;
		} else if (laser == 4) { //last level: opening the 1 sector
			Destroy (goal);
		}
	}
}
