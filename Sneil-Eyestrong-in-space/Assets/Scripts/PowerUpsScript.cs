using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUpsScript : MonoBehaviour {

	public string currentPowerUp = "";
	private float disabledAlpha;
	private float enabledAlpha;
	// Use this for initialization
	void Start () {
		disabledAlpha = this.GetComponent<Image> ().color.a;
		enabledAlpha = 1;
		Globals.POWER_UP = "";
		currentPowerUp = Globals.POWER_UP;
	}
	
	// Update is called once per frame
	void Update () {
		currentPowerUp = Globals.POWER_UP;

		if (currentPowerUp != "") {
			switch (currentPowerUp) {
			case "slow-mo":
				{
					Color color = this.GetComponent<Image> ().color;
					color.a = enabledAlpha;
					this.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Used/Borrowed/Textures/slow-mo");
					this.GetComponent<Image> ().color = color; 
					break;
				}			
			}
		} else {
			Color color = this.GetComponent<Image> ().color;
			color.a = disabledAlpha;
			this.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Used/Borrowed/Textures/frame");
			this.GetComponent<Image> ().color = color; 
		}
	}

	public void use(){
		if (currentPowerUp != "" && !Globals.IS_PAUSED) {
			switch (currentPowerUp) {
			case "slow-mo":
				{
					Globals.SLOWMO = true;
					break;
				}			
			}
			Globals.POWER_UP = "";

		}
	}

}
