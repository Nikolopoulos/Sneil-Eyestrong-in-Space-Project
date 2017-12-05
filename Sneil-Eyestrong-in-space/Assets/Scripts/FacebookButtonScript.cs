using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Facebook.Unity;

public class FacebookButtonScript : MonoBehaviour {

    // Use this for initialization
    bool addedLoginListener = false;
    bool addedLogoutListener = false;

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<Text>().enabled)
        {
            if (Globals.LOGGEDIN && !addedLogoutListener )
            {
                this.GetComponent<Text>().text = "Logout";
                this.GetComponentInParent<Button>().onClick.RemoveAllListeners();
                this.GetComponentInParent<Button>().onClick.AddListener(() => { GameObject.FindGameObjectWithTag("Social").GetComponent<FacebookLogin>().logout(); });
                Debug.Log(GetComponentInParent<Button>().onClick);
                addedLogoutListener = true;
                addedLoginListener = false;
            }

            if (!Globals.LOGGEDIN && !addedLoginListener)
            {
                this.GetComponent<Text>().text = "Login With Facebook";
                this.GetComponentInParent<Button>().onClick.RemoveAllListeners();
                this.GetComponentInParent<Button>().onClick.AddListener(() => { GameObject.FindGameObjectWithTag("Social").GetComponent<FacebookLogin>().Login(); });
                Debug.Log(GetComponentInParent<Button>().onClick);
                addedLogoutListener = false;
                addedLoginListener = true;
            }
        }
    }
}
