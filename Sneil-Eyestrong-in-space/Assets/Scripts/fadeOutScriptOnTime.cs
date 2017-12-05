using UnityEngine;
using System.Collections;

public class fadeOutScriptOnTime : MonoBehaviour {

	// Use this for initialization
	public GameObject[] faders;
	public float startTime;
	private float startingAlpha = 0;
	private bool played=false;
	private float nextAlpha = 0;
	public float fadingFactor = 1;
	CinematicGlobals globals;
	public GameObject audioSource;
	private float startingVolume =1;
	public AudioSource speech;

	void Start () {
		globals = GameObject.FindGameObjectWithTag ("Globals").GetComponent<CinematicGlobals> ();
		faders = GameObject.FindGameObjectsWithTag("fadeout");
		foreach (GameObject plane in faders) {			
			plane.GetComponent<Renderer>().material.SetColor("_Color",new Color(0,0,0,nextAlpha));
		}
	}

	// Update is called once per frame
	void Update () {
		if (globals.speechEnded || globals.skip) {
			if (speech != null) {
				speech.volume = 0;
			}
			foreach (GameObject plane in faders) {
				nextAlpha = plane.GetComponent<Renderer> ().material.color.a + 0.01f;
				plane.GetComponent<Renderer>().material.SetColor("_Color",new Color(0,0,0,nextAlpha));
				Debug.Log ("nextalpha is "+nextAlpha);


					Debug.Log ("Volume is " + audioSource.GetComponent<AudioSource> ().volume);
					audioSource.GetComponent<AudioSource> ().volume = Mathf.Lerp(audioSource.GetComponent<AudioSource> ().volume,0, 0.01f);

				//Debug.Log ("Volume Calculation is " + startingVolume + " - (1 - " + nextAlpha + ") * (" + startingVolume + "/1) = " + audioSource.GetComponent<AudioSource> ().volume);
				//Debug.Log ("Volume Calculation is " + startingVolume + " - "+(1 - nextAlpha)+" * ("+(startingVolume/1)+ ") = " + audioSource.GetComponent<AudioSource> ().volume);

			}
		}
		else {
			startingVolume = audioSource.GetComponent<AudioSource> ().volume;
		}
		if (nextAlpha > 0.95) {
			nextAlpha = 1;
			globals.fadeOutEnded = true;
			globals.loadNextScene = true;
		}
	}
}
