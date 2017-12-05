using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

	private bool disabled = false;

	void OnTriggerEnter(Collider other) {
		if (!disabled && other.tag.Equals("Player")) {			
			disabled = true;
			Globals.AUDIO_SOURCE.Stop();
			Globals.AUDIO_SOURCE.volume = 1;
			Globals.AUDIO_SOURCE.clip = Globals.SOUND_EFFECTS.SPECIAL_2;
			Globals.AUDIO_SOURCE.Play();
			Globals.MODIFIER += 1;
			Handheld.Vibrate();
			Destroy(gameObject);
		}
	}
}