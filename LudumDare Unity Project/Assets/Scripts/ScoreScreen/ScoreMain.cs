using UnityEngine;
using System.Collections;

public class ScoreMain : MonoBehaviour {

	public GUIText[] texts;
	int index = 0;
	float alphaValue = 0;
	public float fadeSpeed = 0.2f;
	
	GameMan gameManager;
	
	// Use this for initialization
	void Start () 
	{
		gameManager = (GameMan)FindObjectOfType(typeof(GameMan));
		
		if(gameManager)
		{
			gameManager.totalLevelTime += gameManager.actualLevelTime;
			
			GUIText levelPoints = GameObject.Find("points-value").guiText;
			if(levelPoints)
			{
				levelPoints.text = "+" + gameManager.actualLevelScore;
			}
			
			GUIText levelTime = GameObject.Find("Time-value").guiText;
			if(levelTime)
			{
				levelTime.text = gameManager.getLevelFormatedTime();
			}
			
			gameManager.totalGameScore += gameManager.actualLevelScore;
			
			GUIText totalScore = GameObject.Find("Total-value").guiText;
			if(totalScore)
			{
				totalScore.text = gameManager.totalGameScore.ToString();
			}
		}		
		
		alphaValue = 0;
		for(int i = 0; i < texts.Length;i++)
		{
			texts[i].material.color = new Color(0,0,0,0);
		}
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(texts != null && index < texts.Length)
		{
			alphaValue += fadeSpeed* Time.deltaTime;
			
			if( alphaValue >= 1)
			{
				alphaValue = 1;
				texts[index].material.color = new Color(1,1,1,alphaValue);
			 	index ++;
				alphaValue = 0;
			}else
			{
				texts[index].material.color = new Color(1,1,1,alphaValue);
			}
		}
		
		if(Input.anyKey)
		{
			if(index == texts.Length)
				Application.LoadLevel(gameManager.nextLevel);
			else
				fadeSpeed = 10;
			
		}
	
	}
}
