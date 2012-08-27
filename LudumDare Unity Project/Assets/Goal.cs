using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	
	public int nextLevel;
	float totalTime = 0;
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void changeLevel()
	{
		Application.LoadLevel(nextLevel);
	}
	
	
	void OnTriggerEnter(Collider c) 
	{
		if(c.gameObject.tag == "Player")
		{
		
			Color co = new Color(c.renderer.material.color.r,c.renderer.material.color.g,c.renderer.material.color.b,renderer.material.color.a);
			renderer.material.color = co;
		

		}
	}
	
	 void OnTriggerStay(Collider c) 
	{
		if(c.gameObject.tag == "Player")
		{
			totalTime += Time.deltaTime;

			renderer.material.color = new Color(renderer.material.color.r+0.1f,renderer.material.color.g+0.1f ,renderer.material.color.b +0.1f,renderer.material.color.a );
			
			if(totalTime >= 3)
				changeLevel();
		}
	}
}
