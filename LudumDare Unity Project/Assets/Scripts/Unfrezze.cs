using UnityEngine;
using System.Collections;

public class Unfrezze : MonoBehaviour {
	
	public GameObject target;
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
			target.rigidbody.constraints = RigidbodyConstraints.None;
			target.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |  RigidbodyConstraints.FreezePositionZ;
			target.rigidbody.useGravity = true;
		}
	}
}
