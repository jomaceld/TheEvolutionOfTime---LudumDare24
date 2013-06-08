using UnityEngine;
using System.Collections;

public class rotateObject : MonoBehaviour {
	
	
	Vector3 rot;
	bool cubesNotCreated = true;
	
	int state = 0;
	float elapsedTime = 0;
	
	public GameObject texto1,texto2, texto3;

	// Use this for initialization
	private void Start () {
		
	   rot = transform.rotation.eulerAngles;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(state == 0)
				state = 1;
		}
		
		if(state == 0)
		{
			texto1.SetActive(true);
			transform.RotateAroundLocal(Vector3.up, 5*Time.deltaTime*0.1f);
			transform.RotateAroundLocal(Vector3.forward, 5*Time.deltaTime*0.2f);
			transform.RotateAroundLocal(Vector3.right, 5*Time.deltaTime*0.3f);
			
		}else if (state == 1)
		{
			elapsedTime += Time.deltaTime;
			texto1.SetActive(false);
			
		
			if(elapsedTime < 5 )
			{
				texto2.SetActive(true);
				transform.RotateAroundLocal(Vector3.up, 5*Time.deltaTime*0.1f);
				transform.RotateAroundLocal(Vector3.forward, 5*Time.deltaTime*0.2f);
				transform.RotateAroundLocal(Vector3.right, 5*Time.deltaTime*0.3f);
				
				float rate = 1/5.1f;
				transform.localScale += new Vector3(-rate*Time.deltaTime,-rate*Time.deltaTime, -rate*Time.deltaTime);
				
			}else if(elapsedTime < 7  )
			{
				texto2.SetActive(false);
				texto3.SetActive(true);
				GameObject sourceCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				if(cubesNotCreated)
				{
					System.Random rand  = new System.Random(); 
					
					for (int x = 0; x < 200 ; x++) {
		            	GameObject cube = (GameObject) GameObject.Instantiate(sourceCube);
		           	 	cube.AddComponent<Rigidbody>();
						cube.renderer.material = renderer.material;
		            	cube.transform.position = transform.position + new Vector3((float)(rand.NextDouble()*2 ) -1,(float)(rand.NextDouble()*2 )-1,(float)(rand.NextDouble()*2 )-1);
						cube.transform.localScale = new Vector3 ( 0.05f,0.05f,0.05f);
						cube.renderer.material.color = getRandomColor();
						cube.rigidbody.useGravity = false;
						cube.rigidbody.AddExplosionForce(100,transform.position,100);
						//cube.rigidbody.drag = 0.5f;
						//cube.rigidbody.angularDrag
		        	}
					gameObject.AddComponent<Rigidbody>();
					this.rigidbody.useGravity = false;
					this.rigidbody.AddExplosionForce(20,transform.position,100);
					
					cubesNotCreated = false;
				}
			}else if(elapsedTime > 12  )
			{
				Application.LoadLevel(1);
			}
		}
			

	}
	
	public Color getRandomColor()
	{
		Color returnColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
		
		return returnColor;
	}
}
