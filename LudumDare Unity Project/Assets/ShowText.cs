using UnityEngine;
using System.Collections;

public class ShowText : MonoBehaviour {
	
	public string text;
	public float time = 5;
	bool show = true;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void OnTriggerEnter(Collider c) 
	{
		if(c.gameObject.tag == "Player" && show)
		{
			c.GetComponent<Character>().showText(text,time);
			show = false;
		}
	}
}
