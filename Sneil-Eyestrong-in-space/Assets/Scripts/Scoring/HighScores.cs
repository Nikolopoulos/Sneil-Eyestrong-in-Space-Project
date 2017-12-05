using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

[System.Serializable]
public class HighScores {

	private List<Score> scores;
	public HighScores () {
		Load();
	}
	
	public bool submitScore(Score arg0){
		int whereToInsert=-1;
		for(int i=0;i<scores.Count;i++) {
			if(arg0.getPoints()>scores[i].getPoints()){
				whereToInsert=i;
				break;
			}
		}
		if(whereToInsert==-1&&scores.Count<10) {
			scores.Add(arg0);
			Save();
			return true;
		}
		else if(whereToInsert!=-1) {
			List<Score> temp = new List<Score>();
			for(int i=0;i<whereToInsert;i++) {
				temp.Add(scores[i]);				
			}
			temp.Add(arg0);
			for(int i=whereToInsert;i<scores.Count;i++) {
				temp.Add(scores[i]);				
			}
			
			scores=temp;			
			while(scores.Count>10) {
				scores.RemoveAt(10);
			}
			Save();
			return true;
		}
		return false;

	}
	
	public void Load() {
		if(File.Exists(Globals.persistentPath + "/highScores.pwn")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Globals.persistentPath + "/highScores.pwn", FileMode.Open);
			this.scores = (List<Score>)bf.Deserialize(file);
			file.Close();
		}
		else {
			scores = new List<Score>();
		}
	}
	
	public void Save() {		
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Globals.persistentPath + "/highScores.pwn");
		bf.Serialize(file, this.scores);
		file.Close();
	}
	
	public override string ToString() {
		string returning ="";
		for(int i =0;i<scores.Count;i++) {
			returning += scores[i].ToString()+"\n";
		}
		return returning;
	}

	public void clear() {
		scores = new List<Score>();
		Save();
	}

	public List<Score> getScores() {
		return scores;
	}
}
