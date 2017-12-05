using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private const int NONE = -1;
	private const int UP = 0;
	private const int DOWN = 1;
	private const int LEFT = 2;
	private const int RIGHT = 3;

    private float demopointer_x;
    private float demopointer_y;

    private readonly Vector3 X = new Vector3(1, 0, 0);
	private readonly Vector3 Y = new Vector3(0, 1, 0);
	private readonly Vector3 Z = new Vector3(0, 0, 1);

	//BarelRoll
	public float barelRollDistance = 70f;
	public float barelRollTime = 0.5f;
	private float barelRollTimer;
	private int rollDirection = NONE;

	//DoubleTap
	private float lastTapTime = 0;
	private float doubleTapMargine = 10f;
	private int firstTapSideOfScreen = -1; //0 left 1 right
	private int secondTapSideOfScreen = -1; //0 left 1 right
	private float middle;
	private float totalTimeInScene = 0;

	//NormalMovement
	public float movementSpeed = 100;
	public float movementDelay = 0.3f;
	public float rotationSpeed = 1.2f;
	public float rotationDelay = 0.1f;
	public float yBias = 1.5f;
	public float buttonBias = 0.8f;
	private Vector3 initialPosition;
	private Vector3 targetPosition;
	private Quaternion targetRotation;
	private Quaternion initialRotation;
	private float mod;

	//Time control
	private float timeTimer = 0f;
	private bool canSlow = false;
	private bool inSlow = false;
	private float timeInSlow = 0f;

	//CameraBounds
	private Camera mainCamera;
	private Vector3 bottomLeft;
	private Vector3 topRight;
    //ViewportToWorldPoint
    void Awake () {
		barelRollTimer = barelRollTime;
		mainCamera = Globals.CAMERA;
        Vector3 screenbottomleft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, Globals.PLAYER.transform.position.z));
        Vector3 screentopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Globals.PLAYER.transform.position.z));
        initialPosition = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.4f, transform.position.z - mainCamera.transform.position.z));
        bottomLeft = screenbottomleft;
        //mainCamera.ViewportToWorldPoint(new Vector3(screenbottomleft.x, screenbottomleft.y, transform.position.z - mainCamera.transform.position.z));
        topRight = screentopRight;
        //mainCamera.ViewportToWorldPoint(new Vector3(screentopRight.x, screentopRight.y, transform.position.z - mainCamera.transform.position.z));
		targetPosition = initialPosition;
		initialRotation = transform.rotation;
		middle = Screen.width/2;
        Debug.Log("botomLeft: "+bottomLeft);
        Debug.Log("topRight: " + topRight);
    }

	void Update () {
        if (Globals.STATE == Globals.MENU) {
            demoMovement();
            return;
        }
        canSlow = Globals.SLOWMO;
		totalTimeInScene += Time.deltaTime;
		Globals.ROLL_COUNT++;
		if (!Globals.IN_GUI) {
			Screen.lockCursor = true;
		} else {
			Screen.lockCursor = false;
			return;
		}
		if (Globals.PLAYER_WON) {
			//specialMovement();
			normalMovement ();
		} else if (barelRollTimer < barelRollTime) {
			barelRollMovement ();
		} else if (Globals.PLAYER_LOST) {
		} else {
			normalMovement();
		}
		reachPoint();
	}

	private void specialMovement() {
		mod = 1;
		reachPoint ();
	}

	private void barelRollMovement() {
		
		/*mod = 2;
		barelRollTimer += Time.deltaTime;
		if (barelRollTimer > barelRollTime) {
			barelRollTimer = barelRollTime;
			lastTapTime = 0;
		}

		switch (rollDirection) {
		case LEFT:
			targetPosition = targetPosition - new Vector3(Time.deltaTime * barelRollDistance / barelRollTime, 0, 0);
			targetRotation = initialRotation * Quaternion.AngleAxis(360f * barelRollTimer / barelRollTime, Z);
			break;
		case RIGHT:
			targetPosition = targetPosition + new Vector3(Time.deltaTime * barelRollDistance / barelRollTime, 0, 0);
			targetRotation = initialRotation * Quaternion.AngleAxis(-360f * barelRollTimer / barelRollTime, Z);
			break;
		default:
			normalMovement();
			break;
		}
		
		if (Input.GetMouseButton(2) || Input.GetKey(KeyCode.Space)) {
			Time.timeScale = Mathf.Lerp(Time.timeScale, 0.3f, Time.deltaTime * 4 / Time.timeScale);
			if (Time.timeScale < 0.33f) {
				Time.timeScale = 0.3f;
			}
		}
		
		if (!Input.GetMouseButton(2) && !Input.GetKey(KeyCode.Space)) {
			Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.deltaTime * 4 / Time.timeScale);
			if (Time.timeScale > 0.95f) {
				Time.timeScale = 1;
			}
		}*/
	}

	private void normalMovement() {
		mod = 1;
		float x = 0;
		float y = 0;
		float displacement = movementSpeed * Time.deltaTime;

		float pointer_x=Input.GetAxis("Mouse X");
		float pointer_y=Input.GetAxis("Mouse Y");
		if (Input.touchCount > 0 )
		{
			pointer_x = Input.touches[0].deltaPosition.x/5;
			pointer_y = Input.touches[0].deltaPosition.y/5;
		}
	/*	if (Input.touchCount == 1 && lastTapTime == 0) {
			if (Input.touches [0].position.x > middle) {
				firstTapSideOfScreen = 1;
			} else {
				firstTapSideOfScreen = 0;
			}
			lastTapTime = totalTimeInScene;
			Debug.Log ("Case 1");
		} else if (Input.touchCount == 1 && lastTapTime != 0 && lastTapTime < doubleTapMargine) {
			if (Input.touches [0].position.x > middle ) {
				secondTapSideOfScreen = 1;
			} else {
				secondTapSideOfScreen = 0;
			}
			Debug.Log ("Case 2");
			lastTapTime = totalTimeInScene;
		} else if (Input.touchCount == 1 && lastTapTime != 0 && lastTapTime >= doubleTapMargine) {			
			firstTapSideOfScreen = -1;
			secondTapSideOfScreen = -1;
			lastTapTime = 0;
			Debug.Log ("Case 3");
		} else if (Input.touchCount > 1) {
			firstTapSideOfScreen = -1;
			secondTapSideOfScreen = -1;
			lastTapTime = 0;
			Debug.Log ("Case 4");
		}

		if (secondTapSideOfScreen == firstTapSideOfScreen && firstTapSideOfScreen >-1) {
			Debug.Log ("Case 5");
			if (secondTapSideOfScreen == 0) {
				barelRollTimer = 0f;
				rollDirection = LEFT;
				Globals.ROLL_COUNT++;
				Debug.Log ("Case 6");
			} else {
				barelRollTimer = 0f;
				rollDirection = RIGHT;
				Globals.ROLL_COUNT++;
				Debug.Log ("Case 7");
			}
			firstTapSideOfScreen = -1;
			secondTapSideOfScreen = -1;
		}

		if (Input.GetMouseButtonDown(0) && lastTapTime == 0) {
			if (Input.mousePosition.x > middle) {
				firstTapSideOfScreen = 1;
			} else {
				firstTapSideOfScreen = 0;
			}
			lastTapTime = totalTimeInScene;
			Debug.Log ("Case 1 "+totalTimeInScene);
		} else if (Input.GetMouseButtonDown(0) && lastTapTime != 0 && lastTapTime < doubleTapMargine) {
			if (Input.mousePosition.x > middle) {
				secondTapSideOfScreen = 1;
			} else {
				secondTapSideOfScreen = 0;
			}
			Debug.Log ("Case 2");
			lastTapTime = totalTimeInScene;
		} else if (Input.touchCount == 1 && lastTapTime != 0 && lastTapTime >= doubleTapMargine) {			
			firstTapSideOfScreen = -1;
			secondTapSideOfScreen = -1;
			lastTapTime = 0;
			Debug.Log ("Case 3");
		} else if (Input.touchCount > 1) {
			firstTapSideOfScreen = -1;
			secondTapSideOfScreen = -1;
			lastTapTime = 0;
			Debug.Log ("Case 4");
		}

		if (secondTapSideOfScreen == firstTapSideOfScreen && firstTapSideOfScreen >-1) {
			Debug.Log ("Case 5");
			if (secondTapSideOfScreen == 0) {
				barelRollTimer = 0f;
				rollDirection = LEFT;
				Globals.ROLL_COUNT++;
				Debug.Log ("Case 6");
			} else {
				barelRollTimer = 0f;
				rollDirection = RIGHT;
				Globals.ROLL_COUNT++;
				Debug.Log ("Case 7");
			}
			firstTapSideOfScreen = -1;
			secondTapSideOfScreen = -1;
		}*/

		y = displacement * pointer_y * yBias;//Input.GetAxis("Mouse Y") * yBias;
		x = displacement * pointer_x;//Input.GetAxis("Mouse X");

		if (Input.GetKey(KeyCode.W)) {
			y = displacement * yBias * buttonBias;
		}
		
		if (Input.GetKey(KeyCode.S)) {
			y = -displacement * yBias * buttonBias;
		}
		
		if (Input.GetKey(KeyCode.A)) {
			x = -displacement * buttonBias;
		}
		
		if (Input.GetKey(KeyCode.D)) {
			x = displacement * buttonBias;
		}

		targetPosition = targetPosition + new Vector3(x, y, 0);

		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Q)) {
			//barelRollTimer = 0f;
			//rollDirection = LEFT;
			Globals.ROLL_COUNT++;
		}
		
		if (Input.GetMouseButtonDown (1) || Input.GetKeyDown(KeyCode.E)) {
			//barelRollTimer = 0f;
			//rollDirection = RIGHT;
			Globals.ROLL_COUNT++;
		}

		/*if (!inSlow && Globals.ROLL_COUNT >= rollsPerSec) {
			canSlow = true;
		}*/
		if (Globals.PLAYER_WON || Globals.PLAYER_LOST) {
			canSlow = false;
		}

		/*if ((canSlow && Input.GetMouseButton(2) || Input.GetKey(KeyCode.Space) || Input.touchCount > 1 && !Globals.IS_PAUSED) && (!Globals.PLAYER_LOST || !Globals.PLAYER_WON)) {
			if (!inSlow) {
				timeTimer = 0f;
				inSlow = true;
				Globals.ROLL_COUNT -= rollsPerSec;
			} else {
				timeTimer += Time.deltaTime / Time.timeScale;
			}
			if (timeTimer >= 1.1f) {
				timeTimer -= 1f;
				if (Globals.ROLL_COUNT <  rollsPerSec) {
					canSlow = false;
				} else {
					Globals.ROLL_COUNT -= rollsPerSec;
				}
			}
			Time.timeScale = Mathf.Lerp(Time.timeScale, 0.3f, Time.deltaTime * 4 / Time.timeScale);
			if (Time.timeScale < 0.33f) {
				Time.timeScale = 0.3f;
			}
		}*/

		if ((canSlow && Globals.SLOWMO && ! Globals.IS_PAUSED)) {
			if (!inSlow) {
				timeTimer = 0f;
				inSlow = true;
			} else {
				timeTimer += Time.deltaTime / Time.timeScale;
			}
			if (timeTimer >= 5f) {
					timeTimer = 0;
					canSlow = false;
					Globals.SLOWMO = false;
			}
			Time.timeScale = Mathf.Lerp(Time.timeScale, 0.3f, Time.deltaTime * 4 / Time.timeScale);
			if (Time.timeScale < 0.33f) {
				Time.timeScale = 0.3f;
			}
		}

		if (((inSlow && !canSlow )&& !Globals.IS_PAUSED) || Globals.PLAYER_WON ) {
			timeTimer = 0f;
			if (Time.timeScale > 0.95f) {
				Time.timeScale = 1;
				inSlow = false;
			}
			Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.deltaTime * 4 / Time.timeScale);
		}

		targetRotation = initialRotation * Quaternion.Euler(new Vector3(0f, 0f, rotationSpeed * (transform.position.x - targetPosition.x))) * Quaternion.Euler(new Vector3(rotationSpeed * (transform.position.y - targetPosition.y), 0f, 0f));
	}

    private void demoMovement() {
        mod = 0.3f;
        float x = 0;
        float y = 0;
        float displacement = movementSpeed * Time.deltaTime;

        if (Time.frameCount % 240 == 0)
        {
            demopointer_x = Random.Range(-5, 5);
            demopointer_y = Random.Range(-5, 5);
           
            
        }
        y = displacement * demopointer_y * yBias;//Input.GetAxis("Mouse Y") * yBias;
        x = displacement * demopointer_x;//Input.GetAxis("Mouse X");

        targetPosition = targetPosition + new Vector3(x, y, 0);
        targetRotation = initialRotation * Quaternion.Euler(new Vector3(0f, 0f, rotationSpeed * (transform.position.x - targetPosition.x))) * Quaternion.Euler(new Vector3(rotationSpeed * (transform.position.y - targetPosition.y), 0f, 0f));
        reachPoint();
    }
	private void reachPoint() {
        targetPosition.x = targetPosition.x;
        if (targetPosition.x > topRight.x) {
            targetPosition.x = topRight.x;
        }
        if (targetPosition.x < bottomLeft.x)
        {
            targetPosition.x = bottomLeft.x;
        }
        if (targetPosition.y > topRight.y)
        {
            targetPosition.y = topRight.y;
        }
        if (targetPosition.y < bottomLeft.y)
        {
            targetPosition.y = bottomLeft.y;
        }
        //Mathf.Clamp(targetPosition.x, bottomLeft.x, topRight.x);
		//targetPosition.y = Mathf.Clamp(targetPosition.y, bottomLeft.y, topRight.y);
		targetPosition.z = transform.position.z;
		GameObject cursor = GameObject.FindGameObjectWithTag("Cursor");
		cursor.transform.position = targetPosition;
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / movementDelay * mod);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / rotationDelay);
	}
}