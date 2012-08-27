using UnityEngine;
using System.Collections;

public class rotateCamera : MonoBehaviour {
	
	public Transform cube;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if( Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.RotateAround(cube.position,Vector3.up,180*Time.deltaTime);
			transform.RotateAround(cube.position,Vector3.forward,180*Time.deltaTime);
			transform.RotateAround(cube.position,Vector3.left,180*Time.deltaTime);
			
		}

		
		
	
	
	}
}
