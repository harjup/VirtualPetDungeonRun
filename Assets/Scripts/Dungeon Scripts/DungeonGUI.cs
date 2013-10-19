using UnityEngine;
using System.Collections;

public class DungeonGUI : MonoBehaviour 
{
	public Texture2D myTexture;
	
	Fruit[] fruitsInUse;
	PetBelly petBelly;
	void Start()
	{
		petBelly = GameObject.Find("PetGarden").GetComponent<PetBelly>();
	}
	
	void OnGUI()
	{
		fruitsInUse = petBelly.GetFruitList().ToArray();
		
		Vector2 originPoint = new Vector2(
			GUITools.NormalizeToScreen(GUITools.dimension.x, .1f),
			GUITools.NormalizeToScreen(GUITools.dimension.y, .9f)
			);
		
		//Returns the amount of pixels it takes to cross .005 of the screen
		float screenRatio = GUITools.NormalizeToScreen(GUITools.dimension.x, .005f);

   		if (Event.current.type == EventType.Repaint)
  	 	{
			
			for (int i = 0; i < fruitsInUse.Length; i++) 
			{
				int j = (fruitsInUse.Length - 1) - i;
				
				//for every 1 energy the the current fruit holds, make the fruit's texture the correct ratio of pixels longer
				float maxLength = screenRatio * fruitsInUse[i].getEnergyMax();
				float length = screenRatio * fruitsInUse[i].getEnergy();
				
				float ratio = length/maxLength;
				
				//myTexture.width
				// Paint the full bar. 
		    	Graphics.DrawTexture(
		       	 	new Rect(originPoint.x,originPoint.y,length,25), 
		        	myTexture, // may be replaced with each fruit's particular texture 
		        new Rect(0,0,ratio,1) ,0,0,0,0);
				
				originPoint = new Vector2(originPoint.x + maxLength, originPoint.y);
				
			}		
		} 
	}
	
	
}
