using UnityEngine;
using System.Collections;

public class MeteorDeletion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Transform> ().position.z - Camera.main.transform.position.z < 0) {
			Object.Destroy (this.gameObject);
		}
	}
}
