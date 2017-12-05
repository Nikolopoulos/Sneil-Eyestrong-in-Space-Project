using UnityEngine;
using System.Collections;

public class ArbitaryMovement : MonoBehaviour {

	void Update () {
        if (Globals.STATE != Globals.PLAYING) { return; }
        float z = (float)Globals.GENERAL_SPEED * Time.deltaTime;
		transform.position = transform.position + new Vector3 (0, 0, z);
		Matrix4x4 m = Matrix4x4.TRS(new Vector3(0, 0, z), Quaternion.identity, new Vector3(1, 1, 1));
		Globals.CAMERA.worldToCameraMatrix = m * Globals.CAMERA.worldToCameraMatrix;
	}
}