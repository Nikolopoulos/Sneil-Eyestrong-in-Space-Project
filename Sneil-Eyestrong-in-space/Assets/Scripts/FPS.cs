using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour {
	
	public  float updateInterval = 0.5f;
	
	private float accum = 0;
	private int   frames = 0;
	private float timeleft;
	
	void Start() {
		timeleft = updateInterval;  
	}
	
	void Update() {
		timeleft -= Time.deltaTime;
		accum += Time.timeScale / Time.deltaTime;
		++frames;

		if(timeleft <= 0.0) {
			float fps = accum / frames;
			GetComponent<GUIText>().text = "FPS: " + fps.ToString("F2");
			GetComponent<GUIText>().material.color = Color.green;

			timeleft = updateInterval;
			accum = 0.0f;
			frames = 0;
		}
	}
}
