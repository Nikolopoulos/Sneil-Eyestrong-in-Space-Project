using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {

	// Use this for initialization
	public bool player;
	void Start () {

		//player = true;
		if (!player) {
			transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
		}


	}
	
	// Update is called once per frame
	void Update () {
		//if (player) {
			//rigidbody.velocity = new Vector3 (500*transform.forward.x, 500*transform.forward.y, 500*transform.forward.z);
		//}
		/*if (!player) {
			rigidbody.velocity = new Vector3 (0, 0, -500);
		}*/
		Vector3 pos = transform.position;
		pos += new Vector3((10*transform.forward.x),(10*transform.forward.y),(10*transform.forward.z));
		transform.position = pos;
		Camera cam = Camera.main;
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
		if (!GeometryUtility.TestPlanesAABB (planes, GetComponent<Collider>().bounds)) {
			Destroy(gameObject);		
		}

	}

	void OnTriggerEnter(Collider other){

		if (player && other.gameObject.tag.Equals ("Enemy")) {
			Debug.Log ("HIT!");
			//playSound
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		if (!player && other.gameObject.tag.Equals ("Player")) {
			//playSound
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
