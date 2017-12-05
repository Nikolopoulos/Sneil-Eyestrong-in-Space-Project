using UnityEngine;
using System.Collections;

public class pitchCorrector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<AudioSource> ().pitch = Time.timeScale;
	}
}
