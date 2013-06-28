using UnityEngine;
using System.Collections;

public class TextDescription : MonoBehaviour {
	
	
	Vector2 bk_size;
	Vector2 bk_position;
	public float bk_OpenSpeed = 0.2f;
	public Vector2 bk_MaxSize;
	public string textToDisplay;
	public float lineSpacing = 1.7f; 
	public int MAX_LINES = 5;
	
	
	float lastTime;
	
	
	ArrayList lines;
	int state = -1;
	
	private GUITexture backgroundGUITexture;
	public Texture2D textureBackground;
	
	private GUIText text_guiText;
	public Font font;
	
	public void activateText(string text)
	{
		textToDisplay = text;
		state = 0;
	}
	
	private void initialize()
	{
		// Create Background Texture Object
		GameObject _aux_bk_GOb = new GameObject("BackGroundTexture");
		_aux_bk_GOb.transform.parent = this.transform;
		_aux_bk_GOb.AddComponent<GUITexture>();
		backgroundGUITexture = _aux_bk_GOb.guiTexture;
		backgroundGUITexture.texture = textureBackground;
		bk_size = new Vector2(0,0);
		bk_position = new Vector2(0,0);
		backgroundGUITexture.pixelInset = new Rect(bk_position.x,bk_position.y,(int)bk_size.x,(int)bk_size.y);
		backgroundGUITexture.enabled = true;
		
		// Create GUIText Object
		GameObject _aux_text_GOb = new GameObject("TextBox");
		_aux_text_GOb.transform.parent = transform;
		_aux_text_GOb.AddComponent<GUIText>();
		text_guiText = _aux_text_GOb.guiText;
		text_guiText.font = font;
		text_guiText.lineSpacing = lineSpacing;
		// Fill lines array
		initializeText();
		
		charIndex = 0;
		textSpeed = 0.05f;
		linesDisplayed = 0;
		lineIndex = 0;
	}
	
	private void initializeText()
	{
		lines = new ArrayList();
		string[] words = textToDisplay.Split(' ');
		string l = words[0];
		GUIStyle style = new GUIStyle();
		style.font = text_guiText.font;
		
		for(int i = 1; i< words.Length; i++)
		{
			string w = words[i];
			float width = style.CalcSize( new GUIContent(l+" "+ w)).x;
			if( width < (bk_MaxSize.x - 50) )
			{
				l += " " +w;	
			}else
			{
				lines.Add(l+"\n");
				l = "";
				l = w; 
			}
			
		}
		if(l.Length > 0)
		{
			lines.Add(l+"\n");
		}
	}
	
	
	// Use this for initialization
	void Start () {
		
		lastTime = Time.realtimeSinceStartup;
	}
	
	private void BkAnimation(float eTime)
	{
		backgroundGUITexture.pixelInset = new Rect(bk_position.x,bk_position.y,(int)bk_size.x,(int)bk_size.y);
		
		if( backgroundGUITexture.pixelInset.width < bk_MaxSize.x) {
			bk_size.x += bk_OpenSpeed/eTime;
			// size limit
			if(bk_size.x > bk_MaxSize.x)
				bk_size.x = bk_MaxSize.x;
			bk_position.x = bk_size.x/-2;
		}
		if( backgroundGUITexture.pixelInset.height < bk_MaxSize.y) {
			bk_size.y += bk_OpenSpeed/eTime;
			// size limit
			if(bk_size.y > bk_MaxSize.y)
				bk_size.y = bk_MaxSize.y;
			bk_position.y = bk_size.y/-2;
		}
		
		if( backgroundGUITexture.pixelInset.height == bk_MaxSize.y && 
			 backgroundGUITexture.pixelInset.width == bk_MaxSize.x )
		{
			charIndex = 0;
			state = 2;
		}
	}
	
	int charIndex = 0;
	int lineIndex = 0;
	float sumTime = 0;
	float textSpeed = 0.05f;
	int linesDisplayed = 0;
	private void TextAnimation(float eTime)
	{
		
		// All lines displayed
		if(lineIndex >= lines.Count){
			state = 3;
			return;
		}
		
		// End of page
		if(linesDisplayed > MAX_LINES){
			linesDisplayed = 0;
			state = 3;
			return;
		}
		
		string l = (string)lines[lineIndex];
		if(charIndex == 0)
		{
			text_guiText.pixelOffset = new Vector2(bk_size.x/-2 +20, bk_size.y/2 -20 );
			text_guiText.gameObject.SetActive(true);
			text_guiText.transform.position = new Vector3(text_guiText.transform.position.x,text_guiText.transform.position.y,2);
			text_guiText.text += l[charIndex];
			sumTime = 0;
			charIndex ++;
		}else
		{
			
			sumTime += eTime;
			
			if(sumTime > textSpeed)
			{
				sumTime = 0;
				if(charIndex < l.Length)
				{
					
					if(textSpeed == 0 && (l.IndexOf(" ") >= charIndex) )
					{
						for(int i= charIndex; i <= l.IndexOf(" ") ;i++)
						{
							text_guiText.text += l[i];
							charIndex ++;
						}
						
					}else
					{
						text_guiText.text += l[charIndex];
						charIndex ++;
					}
				}else if((lineIndex) < lines.Count)
				{
					charIndex =0;
					lineIndex ++;
					linesDisplayed ++;
				}else
				{
					state= 3;
				}
					
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		// We need to calculate update time because timeScale might be set to 0
		// and Time.deltaTime might not work;
		float elapsedTime = (Time.realtimeSinceStartup  - lastTime);
		switch(state){
			case 0:
				// Pause game
				Time.timeScale = 0;
				initialize();
				// Next state
				state = 1;
				break;
			case 1:
				// Do animation of the background
				this.BkAnimation(elapsedTime);
				break;
			case 2:
				TextAnimation(elapsedTime);
				if(Input.anyKey )
				{
					textSpeed = 0;
				}
				break;
			case 3:
				if(Input.anyKey)
				{
					if(lineIndex +1 <= lines.Count)
					{
						lineIndex ++;
						charIndex = 0;
						state = 2;
						text_guiText.text = "";
						textSpeed = 0.05f;
						linesDisplayed = 0;
						break;
					}else
					{
						Time.timeScale = 1;
						Destroy(backgroundGUITexture.gameObject);
						Destroy(text_guiText.gameObject);
						state = -1; //Finish
					}
				}
				break;
			default:
				break;
		}
		lastTime = Time.realtimeSinceStartup;
	}
	
	
	
}
