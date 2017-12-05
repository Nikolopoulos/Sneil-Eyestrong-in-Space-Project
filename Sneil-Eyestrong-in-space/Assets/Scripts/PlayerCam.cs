using UnityEngine;
using System.Collections;

public class PlayerCam : MonoBehaviour {

	public float speed = 0.75f;
	public bool start = false;

	void Update() {
		if (start) {
			//transform.position = Globals.CAMERA.transform.position;
		} else if (!Globals.PLAYER_WON) {
			Vector3 newPos = Vector3.Lerp (Globals.CAMERA.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed);
			newPos.z = transform.position.z;
			transform.position = newPos;
			transform.LookAt (new Vector3 (Globals.CAMERA.transform.position.x, Globals.CAMERA.transform.position.y, Globals.CAMERA.transform.position.z + 5000));
		} else {
			
		}
	}
}
