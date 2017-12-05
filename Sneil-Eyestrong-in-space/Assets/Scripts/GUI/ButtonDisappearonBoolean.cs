using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonDisappearonBoolean : MonoBehaviour {

	public bool check;
	CinematicGlobals globals;
	// Use this for initialization
	void Start () {
		globals = GameObject.FindGameObjectWithTag ("Globals").GetComponent<CinematicGlobals> ();
		check = (Globals.PLAYER_LOST || Globals.PLAYER_WON);
	}

	// Update is called once per frame
	void Update () {
		check = (Globals.PLAYER_LOST || Globals.PLAYER_WON);
		if (check) {
			if(this.GetComponent<Image> ()!= null)this.GetComponent<Image> ().enabled = false;
			if(this.GetComponent<Button> ()!= null)this.GetComponent<Button> ().enabled = false;
			if(this.GetComponentInChildren<Text> ()!=null)this.GetComponentInChildren<Text> ().enabled = false;
		}
	}
}
