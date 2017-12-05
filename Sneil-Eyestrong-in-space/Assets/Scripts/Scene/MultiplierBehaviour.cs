using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultiplierBehaviour : MonoBehaviour {

	void Update () {
		if (Globals.PLAYER_WON || Globals.PLAYER_LOST) {
			Debug.Log ("Inside multiplier end condition");
			this.GetComponent<Text>().text = "";
			return;
		}

		this.GetComponent<Text>().text = "X" + Globals.MODIFIER.ToString("F2");
	}
}

