using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserNameText : MonoBehaviour {

    Text text;
    string name;
	// Use this for initialization
	void Start () {
        this.text = this.GetComponent<Text>();
        name = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (name != Globals.PLAYER_NAME) {
            name = Globals.PLAYER_NAME;
            this.text.text = "PLAYER: " + name;
        }
	}
}
