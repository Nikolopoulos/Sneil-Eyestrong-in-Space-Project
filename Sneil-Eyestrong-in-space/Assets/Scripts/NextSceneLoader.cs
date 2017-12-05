using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour {

	CinematicGlobals globals;
	// Use this for initialization
	void Start () {
		globals = GameObject.FindGameObjectWithTag ("Globals").GetComponent<CinematicGlobals> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (globals.loadNextScene) {
			Debug.Log ("update in sceneloader");
			SceneManager.LoadScene (globals.nextScene);
		}
	}
}
