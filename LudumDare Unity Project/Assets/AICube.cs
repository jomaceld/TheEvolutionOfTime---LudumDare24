using UnityEngine;
using System.Collections;


public class AICube : MonoBehaviour {
	
	public Color color;
	public bool forceOn = false;
	public enum forces { Attraction, Repulsion };
	public forces force = forces.Attraction;
	
	// Use this for initialization
	void Start () {
		renderer.material.color = color;

	}
	
	public void makeSmaller(float scale)
	{
				
		transform.localScale -= new  Vector3(scale,scale,scale);
		if( transform.localScale.x <= 0)
			Destroy(gameObject);
	}
	

	
	// Update is called once per frame
	void Update () 
	{
		
		rigidbody.mass = 2 * transform.localScale.x;
		
		if(forceOn)
		{
			RaycastHit hit;
			
			Collider[] basicsInRange = Physics.OverlapSphere(transform.position,5);
			
			for(int i=0; i< basicsInRange.Length; i++)
			{
				if(basicsInRange[i].gameObject.tag == "Player")
				{
					//Debug.DrawLine(transform.position,basicsInRange[i].transform.position);
					Vector3 heading = basicsInRange[i].transform.position - transform.position;
					float normalize =1 -(heading.magnitude / 5);
					
					if(force == forces.Attraction)
					{

						gameObject.rigidbody.AddForce(( heading * 20 * normalize * transform.localScale.x *1.5f ));
					}else
					{

						
						if(transform.localScale.x > 0.2f)
						{
							gameObject.rigidbody.AddForce(-1*( heading * 20 * normalize * transform.localScale.x *1.5f));
						
						}
					}
				}
			}
		}
		
		
	}
}
