using UnityEngine;
using System.Collections;

public class LevelTexture : MonoBehaviour {

	float ScaleToTiles = 0.3f;
	// Use this for initialization
	void Start () {
		
		renderer.material.mainTextureScale = new Vector2(transform.lossyScale.x*ScaleToTiles,transform.lossyScale.y*ScaleToTiles);
   		//renderer.material.mainTextureScale.y = transform.lossyScale.y*ScaleToTiles;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
