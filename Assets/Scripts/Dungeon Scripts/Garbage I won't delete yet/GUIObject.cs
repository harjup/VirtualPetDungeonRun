using UnityEngine;
using System.Collections;

public class GUIObject : MonoBehaviour 
{
	
	Texture2D texture;
	Rect position;
	float lifeTime;
	
	bool isRunning = false;
	
	public void Initialize(Texture2D t, Rect pos, float f)
	{
		texture = t;
		position = pos;
		lifeTime = f;
		
		isRunning = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		if (isRunning)
		{
			GUI.DrawTexture(position, texture,ScaleMode.ScaleToFit);			
			
			
			
			
		}
	}
	
	//Method of drawing only a partial of a graphic, useful for a depleting bar
	/*
	void OnGUI() 
	{ 
		
   		if (Event.current.type == EventType.Repaint)

  	 	{
     	// Paint the full bar. 
    	Graphics.DrawTexture(
        fullTarget, 
        textureLifeBar, 
        fullBar, 0, 0, 0, 0);
   		} 

	}
	*/
}
