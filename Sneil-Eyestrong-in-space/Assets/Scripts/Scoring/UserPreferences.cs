using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

[System.Serializable]
public class UserPreferences
{

    private Dictionary<string,string> preferences;
    public UserPreferences()
    {
        Load();
    }    

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/preferences.pwn"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/preferences.pwn", FileMode.Open);
            this.preferences = (Dictionary<string, string>)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            preferences = new Dictionary<string,string>();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/preferences.pwn");
        bf.Serialize(file, this.preferences);
        file.Close();
    }

    public void set(string key, string value) {
        if (preferences.ContainsKey(key))
        {
            this.preferences[key] = value;
        }
        else {
            this.preferences.Add(key, value);
        }
        Save();

    }

    public string get(string key)
    {
        Load();
        if (preferences.ContainsKey(key))
        {
            return preferences[key];
        }
        else
        {
            return null;
        }
    }

    public void unset(string key) {
        if (preferences.ContainsKey(key))
        {
            preferences.Remove(key);
            Save();
        }
        else
        {
            return;
        }
    }
}
