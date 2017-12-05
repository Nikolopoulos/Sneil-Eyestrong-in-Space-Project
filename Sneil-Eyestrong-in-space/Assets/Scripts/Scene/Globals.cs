using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

	//GENERAL SCENE VARIABLES
	public static bool IN_GUI;
	public static double GENERAL_SPEED;
	public static SoundEffects SOUND_EFFECTS;
	public static double STAGE_TIMER;
	public static double STAGE_TIME_LIMIT;
	public static double ENEMY_CREATION_FREQUENCY;

	//PLAYER STATE VARIABLES
	public static bool PLAYER_LOST;
	public static bool PLAYER_WON;
	public static bool HAS_MAIN_COMPANION;
	public static double PLAYER_HEALTH;

	//power up variables
	public static string POWER_UP = "";
	public static bool SLOWMO = false;

	//SCORING VARIABLES
	public static double MAX_SCORE;
	public static double SCORE;
	public static double BULLET_TIME_COUNTER;
	public static double MODIFIER;
	public static double COLLECTIBLES;
	public static int ROLL_COUNT;

	//IMPORTANT GAME OBJECTS
	public static GameObject PLAYER;
	public static GameObject COMPANION;
	public static GameObject MUSIC;
	public static GameObject CONTROLLER;
	public static Camera CAMERA;
	public static Camera PLAYER_CAMERA;
	public static AudioSource AUDIO_SOURCE;
	public static ObjectPool OBJECT_POOL;
	public static bool IS_PAUSED;
	public static string  Game_Type="Story";

    public static string persistentPath;

	public static string PLAYER_NAME = "Guest";

    //SOCIAL INTERACTION
    public static bool SHARED = false;
    public static bool LOGGEDIN = false;

    //Gameplay control
    //public static bool PLAY=false;

    public static int MENU=1;
    public static int PLAYING=2;
    public static int LIMBO=3;
    public static int STATE = MENU;
}
