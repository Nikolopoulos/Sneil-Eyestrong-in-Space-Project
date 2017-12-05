using UnityEngine;
using System.Collections;

public class soundPlayer : MonoBehaviour {

	public AudioSource source;
	public float startTime;
	bool played = false;
	CinematicGlobals globals;
	// Use this for initialization
	void Start () {
		globals = GameObject.FindGameObjectWithTag ("Globals").GetComponent<CinematicGlobals> ();
	}
	
	// Update is called once per frame

	void Update () {		
		if (globals.totalTimeElapsed > startTime && !played) {
			played = true;
			source.Play ();
		}
		if (played && !source.isPlaying) {
			globals.speechEnded = true;
		}
	}
}
