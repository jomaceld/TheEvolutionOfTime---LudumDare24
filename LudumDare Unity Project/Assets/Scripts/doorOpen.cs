using UnityEngine;
using System.Collections;

public class doorOpen : MonoBehaviour {
	
	bool reduce = false;
	
	public GameObject door;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(reduce)
		{
			float sizeY = door.transform.localScale.y;
			if(sizeY > 0.002f)
			{
				sizeY -= 0.001f/(Time.deltaTime*100);
				if(sizeY < 0)
					sizeY=0;
				door.transform.localScale = new Vector3(door.transform.localScale.x,sizeY,door.transform.localScale.z);
			}
		}
	
	}
	
	
	void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Player" || c.gameObject.tag == "Enemy"){
			if(door){
				reduce = true;
			}
		}
	}
}
