using UnityEngine;
using System.Collections;

public class ProjectilesScript : MonoBehaviour {


	private  ArrayList projectiles ;
	// Use this for initialization
	void Start () {
		projectiles = new ArrayList ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddProjectile(GameObject me){
		projectiles.Add (me);
	}
}
