using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pauseScript : MonoBehaviour {

	private bool isPaused = false;
	private float currentTimescale = 1;
	// Use this for initialization
	void Start () {
		Globals.IS_PAUSED = isPaused;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPaused) {
			currentTimescale = Time.timeScale;
		}
	}

	public void changeState(){
		if (Globals.PLAYER_LOST || Globals.PLAYER_WON) {
			return;
		}
		this.isPaused = !isPaused;
		Globals.IS_PAUSED = isPaused;
		if (isPaused) {
			this.GetComponentInChildren<Text> ().text = "RESUME";
			Time.timeScale = 0;
		} else {
			this.GetComponentInChildren<Text> ().text = "PAUSE";
			Time.timeScale = currentTimescale;
		}
		Debug.Log ("Timescale is now " + Time.timeScale);
	}
}
