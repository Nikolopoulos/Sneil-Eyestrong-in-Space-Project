using UnityEngine;
using System.Collections;

public class fadeInScriptOnStart : MonoBehaviour {

	public GameObject[] faders;

	private float startingAlpha = 1;
	private float nextAlpha = 1;
	public float fadingFactor = 1;
	public GameObject audioSource;
	CinematicGlobals globals;
	public float volumeToStop = 1;
	// Use this for initialization
	void Start () {
		globals = GameObject.FindGameObjectWithTag ("Globals").GetComponent<CinematicGlobals> ();
		faders = GameObject.FindGameObjectsWithTag("fadeout");
		foreach (GameObject plane in faders) {			
			plane.GetComponent<Renderer>().material.SetColor("_Color",new Color(0,0,0,nextAlpha));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (globals.fadeIn && !globals.skip) {
			foreach (GameObject plane in faders) {
				nextAlpha = Mathf.Lerp (nextAlpha, 0, (1/fadingFactor));
				plane.GetComponent<Renderer>().material.SetColor("_Color",new Color(0,0,0,nextAlpha));
				//Debug.Log ("nextalpha is "+nextAlpha);

				if (audioSource.GetComponent<AudioSource> ().volume < volumeToStop) {
					audioSource.GetComponent<AudioSource> ().volume = 1-nextAlpha;
				}
			}
		}
		if (nextAlpha < 0.01) {
            foreach (GameObject plane in faders)
            {
                nextAlpha = 0;
                plane.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 0, nextAlpha));
            }
                
            globals.fadeInEnded = true;
			globals.fadeIn = false;
		}
	}
}
