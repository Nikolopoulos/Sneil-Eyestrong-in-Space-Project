using UnityEngine;
using System.Collections;

public class RotatingAnimation : MonoBehaviour {
	
	public Vector3 axis;
	public float speed;
	
	private bool initialized = false;
	
	public void init() {
		initialized = true;
	}

	void Update () {
		if (!initialized) {
			return;
		}
		transform.rotation = transform.rotation * Quaternion.AngleAxis(speed * Time.deltaTime, axis);
	}
}
