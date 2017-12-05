using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class autoResizer : MonoBehaviour {

	public float widthPercentage=-1;
	public float heightPercentage=-1;

	// Use this for initialization
	void Start () {
		if (widthPercentage > 0 && heightPercentage < 0) {
			float widthToHeightRatio =  this.GetComponent<RectTransform> ().sizeDelta.y /  this.GetComponent<RectTransform> ().sizeDelta.x ;
			GetComponent<RectTransform> ().sizeDelta =  new Vector2 (Screen.width * widthPercentage,Screen.width * widthPercentage * widthToHeightRatio);
			Debug.Log ("Screen width is "+Screen.width+" and "+widthPercentage+" of that is "+(Screen.width * widthPercentage));
		}
		if (widthPercentage < 0 && heightPercentage > 0) {
			float widthToHeightRatio = this.GetComponent<RectTransform> ().sizeDelta.x / this.GetComponent<RectTransform> ().sizeDelta.y;
			GetComponent<RectTransform> ().sizeDelta =  new Vector2 (Screen.height * heightPercentage * widthToHeightRatio,Screen.height * heightPercentage);
		}
		if (widthPercentage > 0 && heightPercentage > 0) {			
			GetComponent<RectTransform> ().sizeDelta =  new Vector2 (Screen.width * widthPercentage ,Screen.height * heightPercentage);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
