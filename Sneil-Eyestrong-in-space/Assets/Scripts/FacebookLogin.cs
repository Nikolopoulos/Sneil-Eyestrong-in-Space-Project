using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Facebook.Unity;

public class FacebookLogin : MonoBehaviour {

	List<string> perms;
    Boolean allowed = false;
	// Use this for initialization
	void Start () {
        UserPreferences prefs = new UserPreferences();
        this.allowed = prefs.get("FBALLOWED") == "true"?true:false;
        Globals.LOGGEDIN = this.allowed;
        perms = new List<string> ();
		perms.Add ("public_profile");
		perms.Add ("email");
		perms.Add ("user_friends");
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}
	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void Login(){        
        FB.LogInWithReadPermissions (perms, AuthCallback);
	}
	private void AuthCallback (ILoginResult result) {
			if (FB.IsLoggedIn) {
				// AccessToken class will have session details
				var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
				// Print current access token's User ID
				Debug.Log(aToken.UserId);
				// Print current access token's granted permissions
				foreach (string perm in aToken.Permissions) {
					Debug.Log(perm);
				}

			FB.API("/me?fields=first_name", Facebook.Unity.HttpMethod.GET, LoginCallback2);
            UserPreferences prefs = new UserPreferences();
            prefs.set("FBALLOWED", "true");
            Globals.LOGGEDIN = this.allowed;
        } else {
				Debug.Log("User cancelled login");
			}
		}
	void LoginCallback2(IGraphResult result)
	{
		if (result.Error != null)
			Debug.Log("Error Response:\n" + result.Error);
		else if (!FB.IsLoggedIn)
			Debug.Log("Login cancelled by Player");
		else{
			IDictionary dict = Facebook.MiniJSON.Json.Deserialize(result.RawResult) as IDictionary;
			Globals.PLAYER_NAME =  dict["first_name"].ToString();
            
            UserPreferences uprefs = new UserPreferences();
            uprefs.set("FBALLOWED", "true");
            Globals.LOGGEDIN = this.allowed;

            print("your name is: " + Globals.PLAYER_NAME);
            UserPreferencesManager prefs = GameObject.FindGameObjectWithTag("UserPreferences").GetComponent<UserPreferencesManager>();
            prefs.changeName(Globals.PLAYER_NAME);
        }
	}
	public void share(){
		FB.ShareLink(new Uri("https://developers.facebook.com/"),"Title","Content",null, ShareCallback);
	}
	public void shareMyScore(){
		FB.ShareLink(new Uri("https://sneil.manatous.gr/download/"),"Hey, I managed to get "+Globals.SCORE+" points in the demo of Sneil!"," Can you beat that?",new Uri("https://scontent.fath3-1.fna.fbcdn.net/v/t31.0-8/17632001_10153979641462255_4803778938614259253_o.jpg?oh=7e63566cc8d35137eeb8bbc0e52ba8f1&oe=59942BE8"), ShareCallback);
	}
	private void ShareCallback (IShareResult result) {
		if (result.Cancelled || !String.IsNullOrEmpty(result.Error)) {
			Debug.Log("ShareLink Error: "+result.Error);
		} else if (!String.IsNullOrEmpty(result.PostId)) {
			// Print post identifier of the shared content
			Debug.Log(result.PostId);
		} else {
			// Share succeeded without postID
			Debug.Log("ShareLink success!");
		}
	}

	public void logout(){

        UserPreferences prefs = new UserPreferences();
        prefs.set("FBALLOWED", "false");
        Globals.LOGGEDIN = false;
        Globals.PLAYER_NAME = "Guest";
		FB.LogOut ();
	}

    public bool isLoggedIn()
    {
        return FB.IsLoggedIn;
    }

}
