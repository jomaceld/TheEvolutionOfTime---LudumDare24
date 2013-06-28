using UnityEngine;
using System.Collections;

public class rotatingCubeFinalLevel : MonoBehaviour {

	// Use this for initialization
	public Transform text;
	public TextMesh score;
	public TextMesh time;
	GameMan gameManager;
	
	void Start () {
		text.renderer.material.SetColor ("_Color", new Color(0,0,0,0));
		
		gameManager = (GameMan)FindObjectOfType(typeof(GameMan));
		if(gameManager)
		{
			score.text = "Total score: " + gameManager.totalGameScore;
			time.text = "Total score: " + gameManager.getTotalFormatedTime();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.RotateAroundLocal(Vector3.up, 5*Time.deltaTime*0.1f);
		transform.RotateAroundLocal(Vector3.forward, 5*Time.deltaTime*0.2f);
		transform.RotateAroundLocal(Vector3.right, 5*Time.deltaTime*0.3f);
		
		if(text.renderer.material.color.a < 1)
		{
			text.renderer.material.SetColor ("_Color", new Color(text.renderer.material.color.r +0.005f,text.renderer.material.color.g+0.005f,text.renderer.material.color.b+0.005f,text.renderer.material.color.a+0.005f));
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			
			Application.LoadLevel(0);
		}
	
	}
}
