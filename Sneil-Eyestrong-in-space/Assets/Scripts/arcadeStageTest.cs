using UnityEngine;
using System.Collections;

public class arcadeStageTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Globals.Game_Type = "Arcade";
	}
    public void Play() {
        Globals.STATE = Globals.PLAYING;
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("playButton").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("End").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("PowerUpUI").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("ScoreCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().clip = Resources.Load("Used/Borrowed/Sounds/Meatball Parade") as AudioClip;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
    }

    public void GoToMenuScreen()
    {
        GameObject.FindGameObjectWithTag("Globals").GetComponent<SceneInitialization>().reset();
        Globals.STATE = Globals.MENU;
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("playButton").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("End").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("PowerUpUI").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("ScoreCanvas").GetComponent<Canvas>().enabled = false;
        //Debug.Log("Listener output " + GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().isPlaying);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
        //Debug.Log("Listener output " + GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().isPlaying);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().clip = Resources.Load("Used/Borrowed/Sounds/Local Forecast Elevator") as AudioClip;
        //Debug.Log("Listener output " + GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().isPlaying);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
        //Debug.Log("Listener output " + GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().isPlaying);
    }

    public void GameOver()
    {
        Globals.STATE = Globals.LIMBO;
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("playButton").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("End").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("PowerUpUI").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("ScoreCanvas").GetComponent<Canvas>().enabled = false;
        //Debug.Log("Listener output " + GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().isPlaying);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
        //Debug.Log("Listener output " + GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().isPlaying);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().clip = Resources.Load("Used/Borrowed/Sounds/Local Forecast Elevator") as AudioClip;
        //Debug.Log("Listener output " + GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().isPlaying);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
        //Debug.Log("Listener output " + GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().isPlaying);
    }
    // Update is called once per frame
    void Update () {
        if (Globals.STATE != Globals.PLAYING)
        {
            if (Globals.STATE == Globals.LIMBO)
            {
                GameObject.FindGameObjectWithTag("End").GetComponent<Canvas>().enabled = true;
            }
            else { GameObject.FindGameObjectWithTag("End").GetComponent<Canvas>().enabled = false; }
            GameObject.FindGameObjectWithTag("PowerUpUI").GetComponent<Canvas>().enabled = false;
            GameObject.FindGameObjectWithTag("ScoreCanvas").GetComponent<Canvas>().enabled = false;
            //Time.timeScale = 0;
            return;
        }
        if (Time.time < 5) {
            return;
        }
        if (Globals.GENERAL_SPEED < 1100)
        {
            Globals.GENERAL_SPEED += 1;
            //Debug.Log("Speed is now " + Globals.GENERAL_SPEED);
        }
        else if (GameObject.FindGameObjectWithTag("Globals").GetComponent<EnemyCreator>().range1 > 0.000010)
        {
            GameObject.FindGameObjectWithTag("Globals").GetComponent<EnemyCreator>().range1 -= 0.0001f;
            GameObject.FindGameObjectWithTag("Globals").GetComponent<EnemyCreator>().range2 -= 0.0001f;
            //Debug.Log("Range is now (" + GameObject.FindGameObjectWithTag("Globals").GetComponent<EnemyCreator>().range1 + "," + GameObject.FindGameObjectWithTag("Globals").GetComponent<EnemyCreator>().range2 + ")");
        }
        else if (Globals.GENERAL_SPEED >= 1100 && GameObject.FindGameObjectWithTag("Globals").GetComponent<EnemyCreator>().range1 <= 0.010 && GameObject.FindGameObjectWithTag("Globals").GetComponent<EnemyCreator>().range2 > 0.12) {
            if (Time.frameCount % 10 == 0) {
                GameObject.FindGameObjectWithTag("Globals").GetComponent<EnemyCreator>().range2 -= 0.0001f;
                //Debug.Log("Range is now (" + GameObject.FindGameObjectWithTag("Globals").GetComponent<EnemyCreator>().range1 + "," + GameObject.FindGameObjectWithTag("Globals").GetComponent<EnemyCreator>().range2 + ")");
            }

        }
	}
}
