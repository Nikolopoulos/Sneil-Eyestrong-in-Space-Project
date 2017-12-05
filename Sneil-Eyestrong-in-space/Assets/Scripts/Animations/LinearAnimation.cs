using UnityEngine;
using System.Collections;

public class LinearAnimation : MonoBehaviour {

	public Vector3 target;
	public float speed;

	private float startTime;
	private float totalLength;
	private Vector3 offset;
	private float mod;
	private bool initialized = false;

	public void init() {
		mod = 1;
		if (Random.Range(0, 2) == 1) {
			mod = -1;
		}
		speed = Mathf.Abs(speed);
		startTime = Time.time;
		totalLength = Vector3.Distance(-target, target);
		offset = new Vector3(0, 0, 0);
		initialized = true;
	}

	void Update () {
		if (!initialized) {
			return;
		}
		float distCovered = (Time.time - startTime) * speed * totalLength;
		float fracJourney = distCovered / totalLength;
		if (fracJourney >= 1) {
			mod = -mod;
			fracJourney -= 1;
			startTime = Time.time;
		}
		Vector3 newOffset = Vector3.Lerp(mod * -target, mod * target, Mathf.SmoothStep(0, 1, fracJourney));
		Vector3 step = newOffset - offset;
		transform.position += step;
		offset = newOffset;
	}
}