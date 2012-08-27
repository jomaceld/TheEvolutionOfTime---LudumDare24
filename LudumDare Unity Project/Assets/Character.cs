using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public int maxVelocity = 5;
	Color previousColor;
	bool jumpPressed = false;
	bool textVisible = false;
	float timeTextVisible= 0;
	float maxTimeTextVisible= 10;
	
	
	public TextMesh text;
	
	/*enum type {"Neutral","Positive","Negative",*/
	// Use this for initialization
	void Start () {
		gameObject.rigidbody.AddForceAtPosition( new Vector3(0,0,-1),new Vector3(0,1,1));
		previousColor = renderer.material.color;

	}
	
	bool canMove()
	{
		if( rigidbody.velocity.z > -1*maxVelocity && rigidbody.velocity.z < maxVelocity)		
			return true;
		else
			return false;
	}
	
	bool canJump()
	{
		int count = 0;
		Collider [] co = Physics.OverlapSphere(transform.position,transform.localScale.x -0.1f );
		for(int i =0; i< co.Length; i++)
		{
			if(co[i].tag != "Trigger")
				count ++;
		}
		if( count > 1)
		{
			return true;
		}	
	
		return false;
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		rigidbody.mass = 2 * transform.localScale.x;
		//getInputKeyboard();
		getInputAxisController();
		changeParticleColor();
		
		if(textVisible && timeTextVisible <= maxTimeTextVisible)
		{
			if(!text.gameObject.active)
				text.gameObject.active = true;
			Vector3 position = new Vector3(transform.position.x,transform.position.y+transform.localScale.x+ 1,transform.position.z);
			text.transform.position = Vector3.MoveTowards(text.transform.position,position,Time.deltaTime * 3.5f);
			timeTextVisible += Time.deltaTime;
		}else
		{
			textVisible = false;
			text.gameObject.active = false;
		}
	
	}
	
	public void showText(string line, float time)
	{
		if(text != null)
		{
			Vector3 position = new Vector3(transform.position.x,transform.position.y+transform.localScale.x+1,transform.position.z);
			text.transform.position = position;
			text.text = line.Replace("\\n","\n");
			textVisible = true;
			maxTimeTextVisible = time;
			timeTextVisible = 0;
		}
	}
	
	void getInputAxisController()
	{
		float horizontalAxis = Input.GetAxis("Horizontal"); 
		//float verticalAxis = Input.GetAxis("Vertical");
		
		// KeyBoard
		if(horizontalAxis != 0  && canMove() )
		{
			if(!canJump()) // is in the air
				gameObject.rigidbody.AddForce(0,0,5* horizontalAxis *(2 * transform.localScale.x));
			else
				gameObject.rigidbody.AddForce(0,0,20* horizontalAxis * (2 * transform.localScale.x));
		}
		
		if(Input.GetAxis("Jump") > 0 && canJump() && !jumpPressed)
		{
			jumpPressed = true;
			gameObject.rigidbody.AddForce(0,200 * rigidbody.mass *1.5f,0);
			
		}else if( Input.GetAxis("Jump") == 0)
		{
			jumpPressed = false;
			
		}
		
		if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		/*
		if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(0);
		
		}*/
	}
	
	void getInputKeyboard()
	{
		// KeyBoard
		if(Input.GetKey(KeyCode.RightArrow)  && canMove() )
		{
			if(!canJump()) // is in the air
				gameObject.rigidbody.AddForce(0,0,5);
			else
				gameObject.rigidbody.AddForce(0,0,20);
			
		}
		
		if(Input.GetKey(KeyCode.LeftArrow) && canMove())
		{
			if(!canJump()) // is in the air
				gameObject.rigidbody.AddForce(0,0,-5);
			else
				gameObject.rigidbody.AddForce(0,0,-20);
			
		}
		
		/*if(Input.GetKeyDown(KeyCode.Space) && canJump)
		{
			canJump = false;
			gameObject.rigidbody.AddForce(0,200 * rigidbody.mass,0);
			
		}*/
		
	
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		//canJump = true;
	}
	
	void changeColor(Color c)
	{
		renderer.material.color = Color.Lerp(renderer.material.color,colorMixer(previousColor,c),0.1f);
	}
	
	public Color colorMixer(Color c1, Color c2)
	{
	    float _r = Mathf.Min((c1.r + c2.r)/2,1);
	    float _g = Mathf.Min((c1.g + c2.g)/2,1);
	    float _b = Mathf.Min((c1.b + c2.b)/2,1);
		float _a = Mathf.Min((c1.a + c2.a)/2,1);
	
	    return new Color(_r,_g,_b,_a);
	}
	
	void OnCollisionExit(Collision collision)
	{
		if(collision.gameObject.GetComponent<AICube>() != null)
		{
			
			previousColor = renderer.material.color;
		}
	}
	
	void OnCollisionStay(Collision collision)
	{
		if(collision.gameObject.GetComponent<AICube>() != null)
		{
			
			changeColor(collision.gameObject.GetComponent<AICube>().color);	
			collision.gameObject.GetComponent<AICube>().makeSmaller(0.01f);
		}
	}
	
	void changeParticleColor()
	{
		Color colorToSet  =renderer.material.color;
		colorToSet.a = 0.8f;
		transform.Find("Particles").GetComponent<ParticleRenderer>().materials[0].SetColor("_TintColor", colorToSet) ;
		/*particleAnimator = spawnedParticles.GetComponent<ParticleAnimator>();
        Color[] m_Color = particleAnimator.colorAnimation;
        m_Color[4] = Color.red;
        particleAnimator.colorAnimation = m_Color;*/

	}
	
	
}
