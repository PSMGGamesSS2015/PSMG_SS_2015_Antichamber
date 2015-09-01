using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttonscript : MonoBehaviour {

	public void onclick(int ID){
		Statics.clickid = ID;
		Vector3 rotation;
		switch (ID) {
		case 0:
			controller.menu.GetComponent<Canvas> ().enabled = false;
			Cursor.visible = false;
			break;
		case 1:
			hide("1");
			show("2");
			break;
		case 2:
			Application.Quit ();
			break;
		case 3:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (0f, 1f, -4f);
			Statics.rot = Quaternion.identity;
			break;
		case 4:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (18f, 1f, 5f);
			Statics.rot = Quaternion.identity;
			break;
		case 5:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (46f, 1f, 27f);
			rotation = new Vector3 (0f, 90f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 6:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (30f, 1f, -10f);
			rotation = new Vector3 (0f, -90f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 7:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (50f, 17f, 27f);
			rotation = new Vector3 (0f, 90f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 8:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (55f, 17f, 20f);
			rotation = new Vector3 (0f, 180f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 9:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (-30f, 1f, -4f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 10:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (-30f, 1f, 33f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 11:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (-40f, 1f, 66f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 12:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (-37f, 7f, 90f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 13:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (115f, 51f, 101f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 14:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (25f, 202f, 70f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 15:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (60f, 1f, 64f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 16:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (84f, 10f, 88f);
			rotation = new Vector3 (0f, 90f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 17:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (82f, 2f, 43f);
			rotation = new Vector3 (0f, -90f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 18:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (-90f, 1f, -21f);
			rotation = new Vector3 (0f, 90f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 19:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (20f, 1f, -67f);
			rotation = new Vector3 (0f, 90f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 20:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (28f, 5f, -136f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 21:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (28f, 5f, -136f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 22:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (28f, 5f, -136f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 23:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (28f, 5f, -136f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 24:
			Application.LoadLevel(Application.loadedLevel);
			Statics.pos = new Vector3 (28f, 5f, -136f);
			rotation = new Vector3 (0f, 0f, 0f);
			Statics.rot = Quaternion.Euler(rotation);
			break;
		case 29:
			show("1");
			hide("2");
			hide("3");
			break;
		case 30:
			hide("2");
			show("3");
			break;
		case 31:
			hide("3");
			show("2");
			break;
		default:
			break;
		}
	}

	void hide(string str){
		GameObject go = null;
		foreach (RectTransform tf in controller.menu.GetComponentsInChildren<RectTransform>()) {
			if (tf.gameObject.name == str) {
				go = tf.gameObject;
			}
		}
		foreach (Image img in go.GetComponentsInChildren<Image>()) {
			img.enabled = false;
		}
		foreach (Image img in go.GetComponentsInChildren<Image>()) {
			img.enabled = false;
		}
	}

	void show(string str){
		GameObject go = null;
		foreach (RectTransform tf in controller.menu.GetComponentsInChildren<RectTransform>()) {
			if (tf.gameObject.name == str) {
				go = tf.gameObject;
			}
		}
		foreach (Image img in go.GetComponentsInChildren<Image>()) {
			img.enabled = true;
		}
		foreach (Image img in go.GetComponentsInChildren<Image>()) {
			img.enabled = true;
		}
	}

	void OnLevelWasLoaded(int level) {
		controller.player = GameObject.FindGameObjectWithTag ("Player");
		controller.player.transform.position = Statics.pos;
		controller.player.transform.rotation = Statics.rot;
		if (Statics.clickid == 4) {
			controller.level2 ();
		}if (Statics.clickid == 9 || Statics.clickid == 10 || Statics.clickid >= 18) {
			controller.portalcam.enabled = true;
		}
		if (Statics.clickid >= 11) {
			controller.hasWeapon = true;
			controller.weaponcam.enabled = true;
		}
		if (Statics.clickid >= 9) {
			controller.laser = 1;
		}
		if (Statics.clickid >= 15) {
			controller.laser = 3;
		}
		if (Statics.clickid > 18) {
			controller.hasMask = true;
		}
	}
}
