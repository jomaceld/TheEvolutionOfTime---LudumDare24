using UnityEngine;
using System.Collections;

public class DeadArea : MonoBehaviour {
	
	public float timeLimit = 1;
	float totalTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider c) 
	{
		if(c.gameObject.tag == "Player")
		{
			totalTime += Time.deltaTime;
			
			if(totalTime >= timeLimit)
				Application.LoadLevel(Application.loadedLevel);
		}
	}
}
