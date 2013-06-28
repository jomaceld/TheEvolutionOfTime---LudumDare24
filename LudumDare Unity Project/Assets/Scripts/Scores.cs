using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {
	
	Texture2D background;
	// Use this for initialization
	void Start () {
		
		
		background = new Texture2D(Screen.width,Screen.height);
		
		Color c = new Color(0,0,0,0.2f);
		
		for( int i = 0;i< Screen.width; i++)
			for(int e = 0; e< Screen.height; e++)
				background.SetPixel(i,e,c);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyUp(KeyCode.H))
		{
			GameObject go = new GameObject("blackBackground");
			go.AddComponent<GUITexture>();
			go.guiTexture.texture = background;
			go.transform.position = new Vector3(0,0,2);
			go.guiTexture.pixelInset = new Rect(0,0,background.width,background.height);
		}
	
	}
}
