using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
	
	public GameObject[] prefabs;
	private List<GameObject> objectPool = new List<GameObject>();

	public void generate(int n) {
		for (int i = 0; i < n; i++) {
			int pos = Random.Range(0, prefabs.Length);
			GameObject obj = (GameObject) Instantiate(prefabs[pos]);
			
			float obstacleSize = 22f;
			float mod_x = Random.Range(0.7f, 1.3f);
			float mod_y = Random.Range((3 - mod_x) / 2 - 0.3f, (3 - mod_x) / 2 + 0.3f);
			float mod_z = 3 - mod_x - mod_y;
			obj.transform.localScale = Vector3.Scale(obj.transform.localScale, obstacleSize * new Vector3(mod_x, mod_y, mod_z));

			pool(obj);
		}
	}

	public int availableObjects() {
		return objectPool.Count;
	}

	public GameObject get() {
		int pos = Random.Range(0, objectPool.Count);
		GameObject resp = objectPool[pos];
		objectPool.RemoveAt(pos);
		return resp;
	}

	public void pool(GameObject go) {
		go.transform.position = new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), -200);
		objectPool.Add(go);
	}
}
