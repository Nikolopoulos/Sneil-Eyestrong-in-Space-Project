using UnityEngine;
using System.Collections;

public class PlaySoundAfterTime : MonoBehaviour {

	private float time;	
	public float timeToStart;
	private bool playflag;
	private bool playNow;

	
	// Use this for initialization
	void Start () {
		time = 0;
		playflag = true;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		
		if ((time > timeToStart && playflag)|| playNow && playflag) {
			this.GetComponent<AudioSource>().Play();
			Debug.Log("grit games presents");
			playflag=false;
		}
	}
}
