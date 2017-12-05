using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonAppearOnBoolean : MonoBehaviour {

	public bool check;
	CinematicGlobals globals;
	// Use this for initialization
	void Start () {
		globals = GameObject.FindGameObjectWithTag ("Globals").GetComponent<CinematicGlobals> ();
		check = (Globals.PLAYER_LOST || Globals.PLAYER_WON);
	}
	
	// Update is called once per frame
	void Update () {
		check = ((Globals.PLAYER_LOST || Globals.PLAYER_WON) && Globals.Game_Type =="Arcade");
		if (check) {
			this.GetComponent<Image> ().enabled = true;
			this.GetComponent<Button> ().enabled = true;
			this.GetComponentInChildren<Text> ().enabled = true;
		}
	}
}
