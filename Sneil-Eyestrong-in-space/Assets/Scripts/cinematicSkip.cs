using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cinematicSkip : MonoBehaviour {

	CinematicGlobals globals;
	UnityEngine.UI.Text text;
	float transparent = 0;
	float opaque = 1;
	bool downwards = true;
	float currentTime = 0;
	float coolOffTime = 3f;
	float tapTime = 0;
	// Use this for initialization
	void Start () {
		globals = GameObject.FindGameObjectWithTag ("Globals").GetComponent<CinematicGlobals> ();
		text = GameObject.FindGameObjectWithTag ("SkipText").GetComponent<UnityEngine.UI.Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float nextAlpha = 0;
		currentTime += Time.deltaTime;
		if (Input.touchCount == 3) {					 
				globals.skip = true; 
			Debug.Log ("TapTime is " + tapTime + " CurrentTime is " + currentTime + " minus is " + (currentTime - tapTime));

		} else {
			tapTime = 0;
		}
		if (downwards) {
			nextAlpha = Mathf.Lerp (text.color.a, transparent, 0.1f);
		} else {
			nextAlpha = Mathf.Lerp (text.color.a, opaque, 0.1f);
		}
		if (downwards && text.color.a < 0.01) {
			downwards = !downwards;
		}
		if (!downwards && text.color.a > 0.99) {
			downwards = !downwards;
		}
		text.color = new Color (0,0,0,nextAlpha);
	}
}
