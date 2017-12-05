using UnityEngine;
using System.Collections;

public class SceneInitialization : MonoBehaviour {

	//GENERAL SCENE VARIABLES
	public double GENERAL_SPEED = 5000d;
	public SoundEffects SOUND_EFFECTS;
	public double STAGE_TIMER = 0d;
	public double STAGE_TIME_LIMIT = 60d;
	
	//PLAYER STATE VARIABLES
	public bool PLAYER_LOST = false;
	public bool PLAYER_WON = false;
	public bool HAS_MAIN_COMPANION = false;
	public double PLAYER_HEALTH = 1d;
	
	//SCORING VARIABLES
	public double MAX_SCORE = 100000d;
	public double SCORE = 0d;
	public double BULLET_TIME_COUNTER = 0d;
	public double MODIFIER = 10d;
	public double COLLECTIBLES = 0d;
	
	//IMPORTANT GAME OBJECTS
	public GameObject PLAYER;
	public GameObject COMPANION;
	public GameObject MUSIC;
	public GameObject CONTROLLER;
	public Camera CAMERA;
	public Camera PLAYER_CAMERA;
	public AudioSource AUDIO_SOURCE;


	private bool choseName = false;
	private bool done = false;

	public double enemyFrequency = 1;

	public void Awake() {
        init();
	}

    public void init() {
        QualitySettings.vSyncCount = 1;
        Time.timeScale = 0f;
        Globals.persistentPath = Application.persistentDataPath;
        Globals.IN_GUI = true;
        Globals.PLAYER_NAME = Globals.PLAYER_NAME == null ? "Guest" : Globals.PLAYER_NAME;
        Globals.GENERAL_SPEED = GENERAL_SPEED;
        Globals.SOUND_EFFECTS = SOUND_EFFECTS;
        Globals.STAGE_TIMER = STAGE_TIMER;
        Globals.STAGE_TIME_LIMIT = STAGE_TIME_LIMIT;
        Globals.PLAYER_LOST = PLAYER_LOST;
        Globals.PLAYER_WON = PLAYER_WON;
        Globals.HAS_MAIN_COMPANION = HAS_MAIN_COMPANION;
        Globals.PLAYER_HEALTH = PLAYER_HEALTH;
        Globals.MAX_SCORE = MAX_SCORE;
        Globals.SCORE = SCORE;
        Globals.BULLET_TIME_COUNTER = BULLET_TIME_COUNTER;
        Globals.MODIFIER = MODIFIER;
        Globals.COLLECTIBLES = COLLECTIBLES;
        Globals.PLAYER = PLAYER;
        Globals.COMPANION = COMPANION;
        Globals.MUSIC = MUSIC;
        Globals.CAMERA = CAMERA;
        Globals.PLAYER_CAMERA = PLAYER_CAMERA;
        Globals.CONTROLLER = CONTROLLER;
        Globals.AUDIO_SOURCE = AUDIO_SOURCE;
        Globals.SCORE = 0f;
        Globals.ROLL_COUNT = 0;
        Globals.ENEMY_CREATION_FREQUENCY = enemyFrequency;
        Time.timeScale = 1f;
        Globals.SCORE = 0;
    }

    public void reset() {
        GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<HealthScript>().reset();
       
        Vector3 currPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        currPosition.x = 83;
        currPosition.y = 0;
        GameObject.FindGameObjectWithTag("Player").transform.position = currPosition;
        GameObject.FindGameObjectWithTag("Globals").AddComponent<ArbitaryMovement>();
        Globals.GENERAL_SPEED = GENERAL_SPEED;

        Globals.STAGE_TIMER = STAGE_TIMER;

        Globals.PLAYER_LOST = PLAYER_LOST;
        Globals.PLAYER_WON = PLAYER_WON;

        Globals.PLAYER_HEALTH = PLAYER_HEALTH;
        Globals.SCORE = 0f;
        Time.timeScale = 1f;
        Globals.SCORE = 0;

    }
	
	void OnGUI() {
		if (!Globals.IN_GUI) {
			return;
		}
		
		/*Globals.PLAYER_NAME = GUI.TextField (new Rect (300, 270, 200, 20), Globals.PLAYER_NAME, 12);
		if (GUI.Button(new Rect(300, 300, 80, 20), "Ready!")) {
			
			return;
		}*/
		choseName = true;
	}

	void Update() {
		if (done || !choseName) {
			return;
		}
		done = true;

		Globals.IN_GUI = false;
	}
}