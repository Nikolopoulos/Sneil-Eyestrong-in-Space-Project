using UnityEngine;
using System.Collections;

public class ObjectReducer : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			Destroy(other.gameObject);
		}
	}
}