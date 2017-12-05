using UnityEngine;
using System.Collections;

[System.Serializable]
public class Score{

	private string Name;
	private long points;
	
	public Score(string arg0, long arg1){
		Name=arg0;
		points=arg1;	
	}
	
	public void setName(string arg0){
		Name=arg0;
	}
	
	public void setPoints(long arg0){
		points=arg0;
	}
	
	public string getName(){
		return Name;
	}
	
	public long getPoints(){
		return points;
	}
	
	public override string ToString(){
		return Name + "    " + points;
	}
}
