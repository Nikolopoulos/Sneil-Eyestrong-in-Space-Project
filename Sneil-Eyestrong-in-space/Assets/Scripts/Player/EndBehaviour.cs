using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using System.Collections;

public class EndBehaviour : MonoBehaviour {

	private HighScores highScores;
	private bool done = false;
	private float nextStageIn =5f;
	private float timeElapsed =0f;
    private bool triggeredOver = false;

	void Awake () {
		
		highScores = new HighScores();
		GetComponent<GUIText>().enabled = false;
		GetComponent<GUIText> ().fontSize = 50;
	}

	void Update () {
		if (Globals.STATE == Globals.LIMBO) {
			//Debug.Log ("timeElapsed ="+timeElapsed);
			timeElapsed += Time.deltaTime;
		}
		if (timeElapsed > nextStageIn) {
            if (Globals.PLAYER_LOST && !triggeredOver) {
                GameObject.FindGameObjectWithTag("Globals").GetComponent<arcadeStageTest>().GoToMenuScreen();
                triggeredOver = true;
            }           
		}
		if (done) {
            //GameObject.FindGameObjectWithTag("Globals").GetComponent<arcadeStageTest>().GoToMenuScreen();
            done = false;
        }
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.C)) {
			highScores.clear();
		}
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.W)) {
			Globals.PLAYER_WON = true;
		}
		if (Globals.PLAYER_LOST) {
            Globals.STATE = Globals.LIMBO;
            //handle losing
            //Debug.Log("LIMBOOO");
            GameObject.FindGameObjectWithTag("End").GetComponent<Canvas>().enabled = true;
            Text text = GameObject.FindGameObjectWithTag("EndText").GetComponent<Text>();
			text.text = "YOU DONE REKT NOW!";

			if (highScores.submitScore (new Score (Globals.PLAYER_NAME, long.Parse (Globals.SCORE.ToString ("F0"))))) {
				text.text += "\n New High Score: "+Globals.SCORE.ToString("F0");
			} else {
				text.text += "\nYour Score: "+Globals.SCORE.ToString("F0");
			}
			highScores.Load();
			text.text += "\n\n\n\nHighScores\n\n";

			foreach (Score s in highScores.getScores()) {
				string name = s.getName();
				while (name.Length < 14) {
					name += " ";
				}
				text.text += name + "|" + s.getPoints().ToString("N0") + "\n";
			}
		} /*else if (Globals.PLAYER_WON && UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings-1) {
			//handle next stage (goto overworld??)
			GetComponent<GUIText>().text = "Get ready for the next level!";
			GetComponent<GUIText>().enabled = true;
		}  else if (Globals.PLAYER_WON && UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings-1) {
			//handle 
			Text text = GameObject.FindGameObjectWithTag("EndText").GetComponent<Text>();
			text.text = "Thank you for testing!!";
			text.text += "\n\nHighScores!\n\n";

			foreach (Score s in highScores.getScores()) {
				string name = s.getName();
				while (name.Length < 14) {
					name += " ";
				}
				text.text += name + "|" + s.getPoints().ToString("N0") + "\n";
			}
		}*/ else {
			return;
		}

		done = true;
	}
}
