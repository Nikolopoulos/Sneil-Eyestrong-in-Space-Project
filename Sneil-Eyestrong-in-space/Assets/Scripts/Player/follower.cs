using UnityEngine;
using System.Collections;

public class follower : MonoBehaviour {
	GameObject whatToFollow;
	float xOffset;
	float yOffset;
	float zOffset;

    float randomx;
    float randomy;
    float randomz;

    void Start () {
		whatToFollow = Globals.PLAYER;
		xOffset=+15;
		yOffset=+15;
		zOffset=-15;

        randomx = whatToFollow.transform.position.x + xOffset + Random.Range(-100, 100);
        randomy = whatToFollow.transform.position.y + yOffset + Random.Range(-100, 100);
        randomz = whatToFollow.transform.position.z + zOffset;

    }
	
	void FixedUpdate () {
        randomz = whatToFollow.transform.position.z + zOffset;
        if (Time.time % 5 == 0) {
            randomx = whatToFollow.transform.position.x + xOffset + Random.Range(-100, 100);
            randomy = whatToFollow.transform.position.y + yOffset + Random.Range(-100, 100);
            randomz = whatToFollow.transform.position.z + zOffset;
        }
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, randomx, 0.001f),
            Mathf.Lerp(transform.position.y, randomy, 0.001f),
            randomz
            );
		
		transform.rotation = new Quaternion(
			Mathf.Lerp(transform.rotation.x, whatToFollow.transform.rotation.x , 0.1f),
			Mathf.Lerp(transform.rotation.y, whatToFollow.transform.rotation.y , 0.1f),
			Mathf.Lerp(transform.rotation.z, whatToFollow.transform.rotation.z , 0.1f),
			Mathf.Lerp(transform.rotation.w, whatToFollow.transform.rotation.w , 0.1f)			
			);
	}
}