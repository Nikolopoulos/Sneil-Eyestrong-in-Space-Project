
using UnityEngine;
using System.Collections;

public class Touchscript : MonoBehaviour {
		private HealthScript hs;

		void OnTriggerEnter(Collider other) {
			if (other.tag.Equals("PlayerMesh")) {
				other.gameObject.GetComponent<HealthScript>().getRekt(10);
				Globals.MODIFIER = 1;
			}
		}
}
