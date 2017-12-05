using UnityEngine;
using System.Collections;

public class UserPreferencesManager : MonoBehaviour {

    bool initialized = false;
	void Start () {
        
	}

    void Update() {
        if (!initialized) {
            initialized = true;
            if (get("NAME") != null) {
                Globals.PLAYER_NAME = get("NAME");
                //GameObject.FindGameObjectWithTag("Social").GetComponent<FacebookLogin>().Login();
            }
        }
    }

    public void changeName(string newName) {
        UserPreferences prefs = new UserPreferences();
        prefs.set("NAME", newName);
    }

    public string get(string key) {
        UserPreferences prefs = new UserPreferences();
        return prefs.get(key);
    }

    public void  unset(string key)
    {
        UserPreferences prefs = new UserPreferences();
        prefs.unset(key);
    }
}
