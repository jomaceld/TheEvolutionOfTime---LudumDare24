using UnityEngine;
using System.Collections;
using System;


public class AICube : MonoBehaviour {
	
	public Color color;
	public bool forceOn = false;
	public enum forces { Attraction, Repulsion };
	public forces force = forces.Attraction;
	
	// Use this for initialization
	void Start () {
		
		
		float red;
		float green;
		float blue;
		while(true)
		{
			red = UnityEngine.Random.value;
			green = UnityEngine.Random.value;
			blue = UnityEngine.Random.value;
			if((red + green + blue) >1 && (red + green + blue) <2 )
				break;
			
		}
		color = new Color(red,green,blue);
		renderer.material.color = color;
	}
	
	public void makeSmaller(float scale)
	{
		transform.localScale -= new  Vector3(scale,scale,scale);
		if( transform.localScale.y <= 0)
			Destroy(gameObject);
	}
	

	
	// Update is called once per frame
	void Update () 
	{
		
		rigidbody.mass = 2 * transform.localScale.x;
		
		if(forceOn)
		{
			Collider[] basicsInRange = Physics.OverlapSphere(transform.position,5);
			
			for(int i=0; i< basicsInRange.Length; i++)
			{
				if(basicsInRange[i].gameObject.tag == "Player")
				{
					Debug.DrawLine(transform.position,basicsInRange[i].transform.position);
					Vector3 heading = basicsInRange[i].transform.position - transform.position;
					float normalize =1 -(heading.magnitude / 5);
					
					if(force == forces.Attraction) {
						gameObject.rigidbody.AddForce(( heading * 2000 * normalize * transform.localScale.x *3f * Time.deltaTime ));
					}else{
						gameObject.rigidbody.AddForce(-1*( heading * 2000 * normalize * transform.localScale.x *3f * Time.deltaTime));
					}
				}
			}
		}
		
		
	}
}
