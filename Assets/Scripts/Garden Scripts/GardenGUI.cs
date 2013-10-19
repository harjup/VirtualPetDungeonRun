using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GardenGUI : MonoBehaviour 
{
	//enum dimension {x, y};
	GUITools.dimension x_dimension = GUITools.dimension.x;
	GUITools.dimension y_dimension = GUITools.dimension.y;
	
	PetBelly petBelly;
	Inventory petInventory;
	
	
	public GameObject petGardenPrefab;
	
	string message = "";
	
	// Use this for initialization
	void Start () 
	{
		if (!GameObject.Find("PetGarden"))
		{
			Instantiate(petGardenPrefab).name = "PetGarden";
		}
		
		
		petBelly = 		GameObject.Find("PetGarden").GetComponent<PetBelly>();
		petInventory = 	GameObject.Find("PetGarden").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		DrawInventory();
		
		Rect gotoDungeonPos = new Rect(
			GUITools.NormalizeToScreen(x_dimension,.9f),
			GUITools.NormalizeToScreen(y_dimension,.9f),
			GUITools.NormalizeToScreen(x_dimension,.09f),
			GUITools.NormalizeToScreen(y_dimension,.09f)
			);
		
		Rect gotoGatheringPos = new Rect(
			GUITools.NormalizeToScreen(x_dimension,.9f),
			GUITools.NormalizeToScreen(y_dimension,.8f),
			GUITools.NormalizeToScreen(x_dimension,.09f),
			GUITools.NormalizeToScreen(y_dimension,.09f)
			);
		
		Rect userMessagePos = new Rect(
			GUITools.NormalizeToScreen(x_dimension,.05f),
			GUITools.NormalizeToScreen(y_dimension,.8f),
			GUITools.NormalizeToScreen(x_dimension,.8f),
			GUITools.NormalizeToScreen(y_dimension,.15f)
			);
	
		
		GUI.Label(userMessagePos, message);
		
		if (GUI.Button(gotoGatheringPos, "Gather Fruits"))
		{
			//Load gathering scene
			Application.LoadLevel("GatherTest");
		}
		
		if(GUI.Button(gotoDungeonPos, "Go to Dungeon"))
		{
			//Tell pet to try going to dungeon
			//Load in the dungeon scene, keeping the pet's belly and stats objects between scenes
			Application.LoadLevel("DungeonTest");
		}
		
	}
	
	void DrawInventory()
	{
		Dictionary<Fruit, int> fruitDictionary = petInventory.GetFruits();
		Fruit[] fruits = new Fruit[fruitDictionary.Count];
		fruitDictionary.Keys.CopyTo(fruits, 0);
		
		for (int i = 0; i < fruits.Length; i++) 
		{
				Rect fruitPos = new Rect(
			GUITools.NormalizeToScreen(x_dimension, .01f),
			GUITools.NormalizeToScreen(y_dimension, i*.1f+.01f),
			GUITools.NormalizeToScreen(x_dimension,.2f),
			GUITools.NormalizeToScreen(y_dimension,.09f)
			);
			
			if (GUI.Button(fruitPos, fruits[i].GetName() + " x " + fruitDictionary[fruits[i]].ToString()))
			{
				Fruit myFruit = fruits[i];
				
				if (petBelly.EatFruit(myFruit))
				{
					message = "Ate the fruit, now " + petBelly.GetBellyFullness() + " out of " + petBelly.GetBellyCapacity() + " full";
					petInventory.TakeFruit(fruits[i]);
				}
				else
				{	
					message = "Pet is too full";
				}
			}
		}
		
		
	}
	
	
	
	/*
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
	*/
}
