using UnityEngine;
using System.Collections;

public class ShowText : MonoBehaviour {
	
	public string text;
	bool show = true;
	public TextDescription textDescription;

	
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
			if(textDescription != null)
				textDescription.activateText(text);
			show = false;
		}
	}
	
	/*void OnTriggerExit(Collider c) 
	{
		if(c.gameObject.tag == "Player" && !show)
		{
			show = true;
		}
	}*/
}
