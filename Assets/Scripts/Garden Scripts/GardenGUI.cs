using UnityEngine;
using System.Collections;

public class GardenGUI : MonoBehaviour 
{
	enum dimension {x, y};
	
	PetBelly petBelly;
	
	// Use this for initialization
	void Start () 
	{
		petBelly = GameObject.Find("PetGarden").GetComponent<PetBelly>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		Rect feedPetPos = new Rect(
			NormalizeToScreen(dimension.x,.9f),
			NormalizeToScreen(dimension.y,.8f),
			NormalizeToScreen(dimension.x,.09f),
			NormalizeToScreen(dimension.y,.09f)
			);
		
		Rect gotoDungeonPos = new Rect(
			NormalizeToScreen(dimension.x,.9f),
			NormalizeToScreen(dimension.y,.9f),
			NormalizeToScreen(dimension.x,.09f),
			NormalizeToScreen(dimension.y,.09f)
			);
		
		
		if (GUI.Button(feedPetPos, "Feed Pet"))
		{
			//Tell the pet to try eating a power fruit
			Fruit myFruit = new Fruit(Stat.type.power, 15, 2, 20);
			
			if (petBelly.eatFruit(myFruit))
			{
				//Debug.Log("Ate the fruit");
			}
			else
			{
				Debug.Log("Pet is tooo full");	
			}
		}
		
		if(GUI.Button(gotoDungeonPos, "Go to Dungeon"))
		{
			//Tell pet to try going to dungeon
			//Load in the dungeon scene, keeping the pet's belly and stats objects between scenes
			Application.LoadLevel("DungeonTest");
		}
		
	}
	
	
	
	float NormalizeToScreen(dimension d, float ratio)
	{
		if (d == dimension.x)
		{
			return ratio * Screen.width;	
		}
		
		if (d == dimension.y)
		{
			return ratio * Screen.height;
		}
		
		return -1f;
	}
}
