using UnityEngine;
using System.Collections;
using System;

public class LevelControl : MonoBehaviour {
	
	
	GameMan gameManager;
	public int levelID;
	public int nextLevelID;
	GameObject scoreText;
	GameObject timeText;
	public Font font;
	GameObject restartText;
	
	// Use this for initialization
	void Start () {
		
		gameManager = (GameMan)FindObjectOfType(typeof(GameMan));
		
		restartText = new GameObject("RestartText");
		restartText.AddComponent(typeof(GUIText));
		restartText.guiText.text = "Press R to restar the level";
		restartText.transform.position = new Vector3(0.5f,0.5f,0.5f);
		restartText.guiText.pixelOffset = new Vector2((Screen.width/2)- 5,
											(Screen.height/2)-5);
		restartText.guiText.anchor = TextAnchor.UpperRight;
		restartText.guiText.font = font;
		
		gameManager.actualLevelScore = 0;
		gameManager.actualLevelTime = 0;
		gameManager.actualGameLevel = 1;
		gameManager.nextLevel = nextLevelID;
		
		scoreText = new GameObject("ScoreText");
		scoreText.AddComponent(typeof(GUIText));
		scoreText.transform.position = new Vector3(0.5f,0.5f,0.5f);
		scoreText.guiText.pixelOffset = new Vector2((Screen.width/-2)+5,
											(Screen.height/2)-5);
		scoreText.guiText.font = font;
		
		timeText = new GameObject("TimeText");
		timeText.AddComponent(typeof(GUIText));
		timeText.transform.position = new Vector3(0.5f,0.5f,0.5f);
		timeText.guiText.pixelOffset = new Vector2((Screen.width/-2)+5,
											(Screen.height/2)-15);
		timeText.guiText.font = font;
	}
	
	// Update is called once per frame
	void Update () {
	
		gameManager.actualLevelTime += (int)(Time.deltaTime *1000);
		scoreText.guiText.text = "Score: " + gameManager.actualLevelScore.ToString();
		timeText.guiText.text = "Time: " + gameManager.getLevelFormatedTime();
	}
	
	public void increaseScrore(int inc)
	{
		if(inc > 0)
		{
			
			gameManager.actualLevelScore += inc;
		}
		
	}
	
	void Awake() {
        
		DontDestroyOnLoad(this);
    }
	
	public long getTimeMs()
	{
		return gameManager.totalLevelTime;
	}
	
	
	
	
}
