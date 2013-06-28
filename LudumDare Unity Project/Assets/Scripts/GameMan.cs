using UnityEngine;
using System.Collections;
using System;

public class GameMan : MonoBehaviour {
	
	
	public int highScore = 1000;
	public int totalGameScore = 0;
	public int actualLevelScore = 0;
	public int actualGameLevel = 0;
	public bool pauseGame = false;
	public long totalLevelTime;
	public long actualLevelTime;
	
	public int nextLevel;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	} 
	
	//public void 
	
	public string getLevelFormatedTime()
	{
		//TODO: FORMAT timeLeft
		string timeToReturn = "";
		
		timeToReturn += (int)TimeSpan.FromMilliseconds(actualLevelTime).Minutes +":";
		timeToReturn += (int)TimeSpan.FromMilliseconds(actualLevelTime).Seconds + ":";
		timeToReturn += (int)TimeSpan.FromMilliseconds(actualLevelTime).Milliseconds;
		
		return timeToReturn;
	}
	
	
	public string getTotalFormatedTime()
	{
		//TODO: FORMAT timeLeft
		string timeToReturn = "";
		
		timeToReturn += (int)TimeSpan.FromMilliseconds(totalLevelTime).Minutes +":";
		timeToReturn += (int)TimeSpan.FromMilliseconds(totalLevelTime).Seconds + ":";
		timeToReturn += (int)TimeSpan.FromMilliseconds(totalLevelTime).Milliseconds;
		
		return timeToReturn;
	}
	
	
	void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
