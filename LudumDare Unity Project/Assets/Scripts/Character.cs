using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public int maxVelocity = 5;
	Color previousColor;
	bool jumpPressed = false;
	public LevelControl levelControl;
	public Material levelMaterial;
	
	public TextMesh text;
	
	// Use this for initialization
	void Start () {
		gameObject.rigidbody.AddForceAtPosition( new Vector3(0,0,-1),new Vector3(0,1,1));
		previousColor = renderer.material.color;
		levelMaterial.color =  renderer.material.color;
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
		Collider [] co = Physics.OverlapSphere(transform.position,transform.localScale.x +0.05f );
		
		for(int i =0; i< co.Length; i++)
		{
			if(co[i].tag != "Trigger" && co[i].tag != "Player")
			{
				return true;
			}
		}
	
		return false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//rigidbody.mass = 2 * transform.localScale.x;
		getInputAxisController();
		changeParticleColor();
	}
	
	void getInputAxisController()
	{
		int factor = 8000;
		float horizontalAxis = Input.GetAxis("Horizontal");
		if(horizontalAxis != 0  && canMove() )
		{
			if(!canJump())
				factor = 4000;
			
			gameObject.rigidbody.AddForce(0,0,factor * horizontalAxis * (transform.localScale.x) *Time.deltaTime );
		}
		
		if(Input.GetAxis("Jump") > 0 && canJump() && !jumpPressed) {
			jumpPressed = true;
			gameObject.rigidbody.AddForce(0,300* rigidbody.mass * 3f,0); // Apply jump force
			
		}else if( Input.GetAxis("Jump") == 0){
			jumpPressed = false;
		}
		
		// Restart level
		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(Application.loadedLevel);
		}
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
			// Update Player Color
			changeColor(collision.gameObject.GetComponent<AICube>().color);
			// Reduce AI cube size
			collision.gameObject.GetComponent<AICube>().makeSmaller(0.01f);
			// Increase score
			if(levelControl != null)
				levelControl.increaseScrore(5);
		}
	}
	
	void changeColor(Color c)
	{
		renderer.material.color = Color.Lerp(renderer.material.color,colorMixer(previousColor,c),0.05f);
		levelMaterial.color = renderer.material.color;
	}
	
	void changeParticleColor()
	{
		Color colorToSet  =renderer.material.color;
		colorToSet.a = 0.8f;
		transform.Find("Particles").GetComponent<ParticleRenderer>().materials[0].SetColor("_TintColor", colorToSet) ;
	}
	
	public Color colorMixer(Color c1, Color c2)
	{
	    float _r = Mathf.Min((c1.r + c2.r)/2,1);
	    float _g = Mathf.Min((c1.g + c2.g)/2,1);
	    float _b = Mathf.Min((c1.b + c2.b)/2,1);
		float _a = Mathf.Min((c1.a + c2.a)/2,1);
	
	    return new Color(_r,_g,_b,_a);
	}
}
