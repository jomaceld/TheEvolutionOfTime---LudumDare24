using UnityEngine;
using System.Collections;

public class CharacterCamera : MonoBehaviour {
	
	public Transform mainCube;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3(mainCube.position.x +15,mainCube.position.y,mainCube.position.z);
		
		
	
	}
}
