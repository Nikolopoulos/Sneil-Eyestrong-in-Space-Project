using UnityEngine;
using System.Collections;

public class timeKeeper : MonoBehaviour {

	float lastValue =-1;
	CinematicGlobals globals;
	// Use this for initialization
	void Start () {
		globals = GameObject.FindGameObjectWithTag ("Globals").GetComponent<CinematicGlobals> ();
	}
	
	// Update is called once per frame
	void Update () {
		globals.totalTimeElapsed += Time.deltaTime;
		if (Mathf.Floor (globals.totalTimeElapsed) != lastValue) {
			lastValue = Mathf.Floor (globals.totalTimeElapsed);
			//Debug.Log ("Seconds are: "+lastValue );
		}
	}
}
