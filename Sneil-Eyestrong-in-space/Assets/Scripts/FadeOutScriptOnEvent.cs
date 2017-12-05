using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOutScriptOnEvent : MonoBehaviour {

	// Use this for initialization
	public GameObject[] faders;
	public float startTime;
	private float startingAlpha = 0;
	private bool played=false;
	private float nextAlpha = 0;
	public float fadingFactor = 50;
	public GameObject audioSource;
	CinematicGlobals globals;
	private float startingVolume =1;
	void Start () { 
		globals = GameObject.FindGameObjectWithTag ("Globals").GetComponent<CinematicGlobals> ();
		faders = GameObject.FindGameObjectsWithTag("fadeout");
	}

	// Update is called once per frame
	void Update () {		
		if (globals.fadeOut) {
			nextAlpha = Mathf.Lerp (nextAlpha, 1, (1 / fadingFactor));
			foreach (GameObject plane in faders) {				
				plane.GetComponent<Renderer> ().material.SetColor ("_Color", new Color (0, 0, 0, nextAlpha));
				//Debug.Log ("nextalpha is " + nextAlpha);
				audioSource.GetComponent<AudioSource> ().volume = startingVolume - (nextAlpha * startingVolume);
			}

		} else {
			startingVolume = audioSource.GetComponent<AudioSource> ().volume;
		}
		if (nextAlpha > 0.99) {
			nextAlpha = 1;
			globals.fadeOutEnded = true;
			globals.loadNextScene = true;
		}
	}
}
