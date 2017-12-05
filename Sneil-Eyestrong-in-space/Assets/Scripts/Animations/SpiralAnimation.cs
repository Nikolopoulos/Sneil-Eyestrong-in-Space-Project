using UnityEngine;
using System.Collections;

public class SpiralAnimation : MonoBehaviour {
	
	public Vector3 axis;
	public float speed;

	private Vector3 point;
	private bool initialized = false;
	
	public void init() {
		point = new Vector3(0, 0, transform.position.z + 100);
		initialized = true;
	}
	
	void Update () {
		if (!initialized) {
			return;
		}
		transform.RotateAround(point, axis, 360f * speed * Time.deltaTime);
	}
}
