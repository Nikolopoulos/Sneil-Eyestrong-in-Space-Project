using UnityEngine;
using System.Collections;

public class QuitScript : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
		if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftControl)) {
			Application.LoadLevel(1);
		}
	}
}
