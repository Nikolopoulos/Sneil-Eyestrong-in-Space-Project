using UnityEngine;
using System.Collections;

public class MusicStarter : MonoBehaviour {

	bool started;
	// Use this for initialization
	void Start () {
		started = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!started && GameObject.FindGameObjectWithTag("Player")!=null)
		{
			started=true;
			GetComponent<AudioSource>().Play();
		}
	}
}
