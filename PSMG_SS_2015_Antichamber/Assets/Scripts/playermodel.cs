using UnityEngine;
using System.Collections;

//animation of playermodel at B Level
public class playermodel : MonoBehaviour {
	Animation anim;
	bool played = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (played && !anim.isPlaying) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			anim.Play("go");
			played = true;
		}
	}
}

