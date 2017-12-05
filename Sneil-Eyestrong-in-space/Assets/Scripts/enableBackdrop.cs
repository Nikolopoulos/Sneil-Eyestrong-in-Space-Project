using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enableBackdrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentInParent<Text> ().text != "") {
			this.GetComponent<Image> ().enabled = GetComponentInParent<Text> ().enabled;
		}
	}
}

