using UnityEngine;
using System.Collections;

public class NearMiss : MonoBehaviour {

	public static int framesFromLastHit;
	public bool eyes;

	void Update() {
		framesFromLastHit++;
	}

	void OnTriggerEnter(Collider other) {
		if (framesFromLastHit > 20 && other.tag.Equals("Enemy")) {
			Globals.AUDIO_SOURCE.volume = 1;
			Globals.AUDIO_SOURCE.clip = Globals.SOUND_EFFECTS.SPECIAL_1;
			Globals.AUDIO_SOURCE.Play();
			framesFromLastHit = 0;
		}
	}
}