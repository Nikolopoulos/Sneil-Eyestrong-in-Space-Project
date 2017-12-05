using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {
	public bool halt;
	public float range1;
	public float range2;
	public float meteorDistance = 2f;

	private float range2Init;
	private float time;
	private float nextTime;
    private int lastPlayStatus;

	private int MAX_METEORS = 1;
	private float secondsFlying=0;
	private bool isFinishLineReady = false;
	public float stageTime=100f;
	GameObject finish;
	public ArrayList bonusRA = new ArrayList();

	public GameObject[] enemies = new GameObject[0];

	void Start () {
		range2Init = range2;
		
		time = 0;
		nextTime = Random.Range(range1, range2)/100;
	}

	void Update () {
        if (Globals.STATE != Globals.PLAYING) {

            if (lastPlayStatus == Globals.PLAYING) {
                destroyAll();
                secondsFlying = 0;
            }
            return;
        }
        lastPlayStatus = Globals.STATE;
        destroy();
        secondsFlying += Time.deltaTime;
        time += Time.deltaTime;
        if (time > nextTime && secondsFlying > 4) {
            time = 0;
            create();
            nextTime = Random.Range(range1, range2);			
   		}
	}

	void destroy(){
		GameObject[] meteors = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject meteor in meteors) {
			if (meteor.transform.position.z + 10 < GameObject.FindGameObjectWithTag ("Player").transform.position.z) {
				GameObject.Destroy (meteor);
			}
		}
	}
	void destroyAll(){
		GameObject[] meteors = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject meteor in meteors) {			
				GameObject.Destroy (meteor);
		}

		GameObject[] tsakwnes = GameObject.FindGameObjectsWithTag("Collectible");

		foreach (GameObject tsakwnas in tsakwnes) {			
			GameObject.Destroy (tsakwnas);
		}
	}
	void create() {

		int bonus = Random.Range (0, 30);
		if (bonus == 0) {
			
			GameObject bon = (GameObject)Instantiate (Resources.Load<GameObject> ("Used/Ours/Prefabs/Treasure_Chest_Asset/Treasure_Chest_Prefab"));
			bonusRA.Add (bon);
            //bon.transform.localScale = new Vector3 (15f, 15f, 15f);
            float z = (Globals.PLAYER.transform.position - Globals.CAMERA.transform.position).z;
            //+Globals.PLAYER.transform.position.z + (float)Globals.GENERAL_SPEED * meteorDistance))
            bon.transform.position = Globals.CAMERA.ScreenToWorldPoint(new Vector3 (Random.Range (0,Screen.width), Random.Range (0, Screen.height), z));
			bon.transform.position = new Vector3 (bon.transform.position.x, bon.transform.position.y, Globals.PLAYER.transform.position.z + (float)Globals.GENERAL_SPEED * meteorDistance);
			if(Globals.Game_Type == "Story"){
				if (bon.transform.position.z > GameObject.FindGameObjectWithTag ("Finish").transform.position.z) {
					GameObject.Destroy (bon);
					}
			}
		} else if (bonus > 28){
			GameObject bon = (GameObject)Instantiate (Resources.Load<GameObject> ("Used/Ours/Prefabs/clock"));
			bon.GetComponent<powerUpPickup> ().powerup = "slow-mo";
			bonusRA.Add (bon);
			bon.transform.localScale = new Vector3 (15f, 15f, 15f);
			float z = (Globals.PLAYER.transform.position - Globals.CAMERA.transform.position).z;
            bon.transform.position = Globals.CAMERA.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), z));
            bon.transform.position = new Vector3(bon.transform.position.x, bon.transform.position.y, Globals.PLAYER.transform.position.z + (float)Globals.GENERAL_SPEED * meteorDistance);
            if (Globals.Game_Type == "Story") {
				if (bon.transform.position.z > GameObject.FindGameObjectWithTag ("Finish").transform.position.z) {
					GameObject.Destroy (bon);
				}
			}
		}
		int id = Random.Range (0, 5);
		//GameObject mis = (GameObject)Instantiate (Resources.Load<GameObject> ("Used/Ours/Prefabs/Meteors/Meteor1"));
		GameObject mis = (GameObject)Instantiate (Resources.Load<GameObject> ("Abandoned/Meteor"));
		//GameObject entry = (GameObject)Instantiate (Resources.Load<GameObject> ("Used/Ours/Prefabs/CameraCollider"));
		//GameObject exit = (GameObject)Instantiate (Resources.Load<GameObject> ("Used/Ours/Prefabs/CameraCollider"));
		//entry.transform.position = 600 * Vector3.forward;
		//exit.transform.position = 1400 * Vector3.forward;
		//==//entry.transform.parent = mis.transform;
		//exit.transform.parent = mis.transform;
		//entry.GetComponent<CameraSwitch> ().entry = true;
		//exit.GetComponent<CameraSwitch> ().entry = false;
		int type = Random.Range (0, 8);
		if (Globals.Game_Type == "Story") {
			if ((Globals.PLAYER.transform.position.z + (float)Globals.GENERAL_SPEED * meteorDistance) > GameObject.FindGameObjectWithTag ("Finish").transform.position.z) {
				return;
			}
		}
        float mz = (Globals.PLAYER.transform.position - Globals.CAMERA.transform.position).z;
       // mis.transform.position = Globals.CAMERA.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), mz));
       // mis.transform.position = new Vector3(mis.transform.position.x, mis.transform.position.y, Globals.PLAYER.transform.position.z + (float)Globals.GENERAL_SPEED * meteorDistance);

        mis.transform.position = new Vector3(Globals.PLAYER.transform.position.x + Random.Range(-100f, 100f), Globals.PLAYER.transform.position.y + Random.Range(-100f,100f), Globals.PLAYER.transform.position.z + (float) Globals.GENERAL_SPEED * meteorDistance);
		mis.transform.rotation = Quaternion.AngleAxis(Random.Range(-100f, 100f) * type, Vector3.forward);
		type = Random.Range(0, 5);
		float lDisplacement = 40f;
		Vector3 direction;
		float lSpeed = 0.8f;
		LinearAnimation lanim;
		RotatingAnimation ranim;
		type = 0;
		switch (type) {
		case 0:
			return;
		case 1:
			mis.AddComponent<LinearAnimation>();
			direction = Vector3.left;
			lanim = mis.GetComponent<LinearAnimation>();
			lanim.target = lDisplacement * direction;
			lanim.speed = lSpeed;
			lanim.init();
			break;
		case 2:
			mis.AddComponent<LinearAnimation>();
			direction = Vector3.up;
			lanim = mis.GetComponent<LinearAnimation>();
			lanim.target = lDisplacement * direction;
			lanim.speed = lSpeed;
			lanim.init();
			break;
		case 3:
			mis.AddComponent<LinearAnimation>();
			direction = Vector3.left + Vector3.up;
			lanim = mis.GetComponent<LinearAnimation>();
			lanim.target = lDisplacement * direction;
			lanim.speed = lSpeed;
			lanim.init();
			break;
		case 4:
			mis.AddComponent<LinearAnimation>();
			direction = Vector3.right + Vector3.up;
			lanim = mis.GetComponent<LinearAnimation>();
			lanim.target = lDisplacement * direction;
			lanim.speed = lSpeed;
			lanim.init();
			break;
		case 5:
			mis.AddComponent<RotatingAnimation>();
			ranim = mis.GetComponent<RotatingAnimation>();
			ranim.speed = 30f;
			ranim.axis = Vector3.forward;
			ranim.init();
			break;
		case 6:
			mis.AddComponent<RotatingAnimation>();
			ranim = mis.GetComponent<RotatingAnimation>();
			ranim.speed = 30f;
			ranim.axis = Vector3.back;
			ranim.init();
			break;
		default:
			return;
		}
	}
}