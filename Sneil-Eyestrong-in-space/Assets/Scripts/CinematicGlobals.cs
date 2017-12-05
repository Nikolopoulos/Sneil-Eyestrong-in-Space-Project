using UnityEngine;
using System.Collections;

public class CinematicGlobals : MonoBehaviour{
	public bool hasStartedPlaying = false;
	public bool fadeInEnded = false;
	public bool fadeIn = true;
	public bool fadeOutEnded = false;
	public bool speechEnded = false;
	public bool fadeOut = false;
	public float totalTimeElapsed = 0;
	public bool loadNextScene=false;
	public bool skip = false;
	public int nextScene = 1;

}
