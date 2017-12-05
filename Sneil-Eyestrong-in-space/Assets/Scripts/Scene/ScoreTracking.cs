using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracking : MonoBehaviour {

	private SceneInitialization scene;
	private bool done = false;


	void Awake() {		
		
		//Debug.Log (PlayerPrefs.GetFloat ("score"));
		if (PlayerPrefs.HasKey ("score")) {
			Globals.SCORE = PlayerPrefs.GetFloat ("score");
			Globals.SCORE = 0;
		} else {
			Globals.SCORE = 0;
		}
		this.GetComponent<UnityEngine.UI.Text>().text = Globals.SCORE.ToString("N");
	}

	void FixedUpdate() {
		if (Globals.PLAYER_WON || Globals.PLAYER_LOST) {
			this.GetComponent<UnityEngine.UI.Text>().text = "";
			return;
		}
		if (Globals.IN_GUI) {
			this.GetComponent<UnityEngine.UI.Text>().text = "";
			return;
		}
		Globals.STAGE_TIMER += Time.deltaTime;
		if (!Globals.PLAYER_LOST) {
			Globals.SCORE += (1*Globals.MODIFIER);
			Globals.SCORE = Mathf.Floor ((float)Globals.SCORE);
			float setScore = float.Parse (Globals.SCORE.ToString());
			PlayerPrefs.SetFloat ("score",setScore);
			this.GetComponent<UnityEngine.UI.Text>().text = Globals.SCORE.ToString("#########################################");
		} else if (!done) {
			float setScore = float.Parse (Globals.SCORE.ToString());
			PlayerPrefs.SetFloat ("score",setScore);
			done = true;
			Globals.CONTROLLER.GetComponent<EnemyCreator>().halt = true;
			foreach (GameObject o in GameObject.FindObjectsOfType<GameObject>()) {
				if (o.tag == "Enemy") {
					Destroy(o);
				}
			}
			Time.timeScale=1f;
			Globals.PLAYER_WON = !Globals.PLAYER_LOST;
		}
	}
}
