using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	// Use this for initialization
	float health;
	int framesFromLastHit;
	int dieFrames;
	Vector3 explosion;
	public AudioClip damageSFX;

	void Start () {
		health = (float) Globals.PLAYER_HEALTH;
		framesFromLastHit = 0;
		dieFrames = 0;
	}

    public void reset() {
        health = (float)Globals.PLAYER_HEALTH;
        framesFromLastHit = 0;
        dieFrames = 0;
        Globals.PLAYER.GetComponent<Rigidbody>().useGravity = false;
        Globals.PLAYER.GetComponent<Rigidbody>().isKinematic = true;
        Globals.PLAYER.GetComponent<Rigidbody>().mass = 1;
        
    }
	
	// Update is called once per frame
	void Update () {
		framesFromLastHit ++;
		if (dieFrames > 0) {
            if ((dieFrames % 30) == 0)
            {
                Globals.PLAYER.GetComponent<Rigidbody>().AddExplosionForce(1000, new Vector3(0, 0, 1), 5000);
                Handheld.Vibrate();
            }
            Camera.main.transform.LookAt(transform.position);
				dieFrames++;
				if(dieFrames%10==0){
				explosion = transform.position;
				explosion.y += Random.Range(-5,5)*10;
				explosion.z += Random.Range(-5,5)*10;
				explosion.x += Random.Range(-5,5)*10;
				Destroy(gameObject.GetComponent <PlayerMovement>());
				Destroy(GameObject.FindGameObjectWithTag("Globals").GetComponent <ArbitaryMovement>());
				//GetComponent<Rigidbody>().AddExplosionForce(1032f,explosion,100f);
				GameObject mis = (GameObject) Instantiate(Resources.Load<GameObject>("Used/Borrowed/Other/Flame"));
				mis.transform.parent=transform;
				Vector3 explosionOnShip = transform.position;
				explosionOnShip.x+= Random.Range(-5,5);
				explosionOnShip.y+= 0;
				explosionOnShip.z+= Random.Range(-5,5);
				mis.transform.position=explosionOnShip;

			}
		}		
	}

	public void getRekt(float damage){
		//
		if (framesFromLastHit > 20 && health > 0) {
			Handheld.Vibrate();
			Globals.MODIFIER = 1;//Globals.MODIFIER > 1 ? Globals.MODIFIER - 1 : 1;
			framesFromLastHit=0;
			health -= damage;
			Globals.AUDIO_SOURCE.Stop();
			Globals.AUDIO_SOURCE.clip = Globals.SOUND_EFFECTS.DAMAGE_1;
			Globals.AUDIO_SOURCE.Play();

		}

		if (health <= 0&&dieFrames==0) {
			Time.timeScale = 1;
			Globals.STAGE_TIMER = double.MaxValue;
            Debug.Log("Playr LOOOOOOOOOOOOOOOOOOOOOST");
			Globals.PLAYER_LOST = true;
			dieFrames=1;
            Globals.PLAYER.GetComponent<Rigidbody>().useGravity = true;
            Globals.PLAYER.GetComponent<Rigidbody>().isKinematic = false;
            Globals.PLAYER.GetComponent<Rigidbody> ().mass = 100;
			Globals.PLAYER.GetComponent<Rigidbody> ().AddExplosionForce(1000,new Vector3 (0, 1, 0),5000);
				//Destroy (gameObject);
			Globals.CONTROLLER.GetComponent<EnemyCreator>().halt = true;

			Destroy(gameObject.GetComponent<PlayerMovement>());
			Destroy(GameObject.FindGameObjectWithTag("ViewPort").GetComponent<ArbitaryMovement>());
			//transform.parent.transform.GetComponent<Rigidbody>().AddExplosionForce(1032f, explosion, 100f);

			//GameObject mis = (GameObject) Instantiate(Resources.Load<GameObject>("Used/Borrowed/Other/Flame"));
			//mis.transform.parent=transform;

			//Vector3 explosionOnShip = transform.position;
			//explosionOnShip.x+= Random.Range(-5,5);
			//explosionOnShip.y+= 0;
			//explosionOnShip.z+= Random.Range(-5,5);
			//mis.transform.position=explosionOnShip;

		}


	}
}
