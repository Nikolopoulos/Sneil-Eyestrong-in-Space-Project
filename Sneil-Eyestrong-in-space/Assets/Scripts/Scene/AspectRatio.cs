using UnityEngine;
using System.Collections;

public class AspectRatio : MonoBehaviour {

	public float targetAspect = 16.0f / 9.0f;

	void Start() {
		Screen.orientation = ScreenOrientation.Landscape;
		float scaleHeight = GetComponent<Camera>().aspect / targetAspect;
		Rect rect = GetComponent<Camera>().rect;
		
		GetComponent<Camera>().aspect = targetAspect;
		if (scaleHeight < 1.0f) {  
			rect.width = 1.0f;
			rect.height = scaleHeight;
			rect.x = 0;
			rect.y = (1.0f - scaleHeight) / 2.0f;
			Matrix4x4 m = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(1 / scaleHeight, 1, 1));
			GetComponent<Camera>().worldToCameraMatrix = m * GetComponent<Camera>().worldToCameraMatrix;
		} else {
			float scaleWidth = 1.0f / scaleHeight;
			rect.width = scaleWidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scaleWidth) / 2.0f;
			rect.y = 0;
			Matrix4x4 m = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(scaleWidth, 1, 1));
			GetComponent<Camera>().worldToCameraMatrix = m * GetComponent<Camera>().worldToCameraMatrix;
		}
		GetComponent<Camera>().rect = rect;
	}
}
