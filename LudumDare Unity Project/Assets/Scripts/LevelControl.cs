using UnityEngine;
using System.Collections;
using System;

public class LevelControl : MonoBehaviour {
	
	
	long score;
	long totalTime;
	GameObject scoreText;
	GameObject timeText;
	int lives;
	// Use this for initialization
	void Start () {
		
		score = 0;
		totalTime = 0;
		lives = 3;
		
		scoreText = new GameObject("ScoreText");
		scoreText.AddComponent(typeof(GUIText));
		scoreText.transform.position = new Vector3(0.5f,0.5f,0.5f);
		scoreText.guiText.pixelOffset = new Vector2((Screen.width/-2)+5,
											(Screen.height/2)-5);
		
		timeText = new GameObject("TimeText");
		timeText.AddComponent(typeof(GUIText));
		timeText.transform.position = new Vector3(0.5f,0.5f,0.5f);
		timeText.guiText.pixelOffset = new Vector2((Screen.width/-2)+5,
											(Screen.height/2)-15);
	}
	
	// Update is called once per frame
	void Update () {
	
		totalTime += (int)(Time.deltaTime *1000);
		scoreText.guiText.text = score.ToString();
		timeText.guiText.text = getFormatedTime();
	}
	
	public void increaseScrore(int inc)
	{
		if(inc > 0)
		{
			score += inc;
		}
		
	}
	
	public long getTimeMs()
	{
		return totalTime;
	}
	
	public string getFormatedTime()
	{
		//TODO: FORMAT timeLeft
		string timeToReturn = "";
		
		timeToReturn += (int)TimeSpan.FromMilliseconds(getTimeMs()).Minutes +":";
		timeToReturn += (int)TimeSpan.FromMilliseconds(getTimeMs()).Seconds + ":";
		timeToReturn += (int)TimeSpan.FromMilliseconds(getTimeMs()).Milliseconds;
		
		return timeToReturn;
	}
	
	
}
