using UnityEngine;
using System.Collections;

public class powerUpPickup : MonoBehaviour {

	public string powerup = "";
	private bool disabled = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if (!disabled && other.tag.Equals("PlayerMesh")) {			
			disabled = true;
			Globals.POWER_UP = powerup;
			Globals.AUDIO_SOURCE.Stop();
			Globals.AUDIO_SOURCE.volume = 1;
			Globals.AUDIO_SOURCE.clip = Globals.SOUND_EFFECTS.SPECIAL_2;
			Globals.AUDIO_SOURCE.Play();
			Handheld.Vibrate();
			Destroy(gameObject);
		}
	}
}
