using UnityEngine;
using System.Collections;

public class CursorBehaviour : MonoBehaviour {

	void Awake() {
		gameObject.GetComponent<Light>().enabled = false;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.H)) {
			gameObject.GetComponent<Light>().enabled = !gameObject.GetComponent<Light>().enabled;
		}
		if (Globals.PLAYER_LOST || Globals.PLAYER_WON) {
			gameObject.GetComponent<Light>().enabled = false;
		}
	}
}
