using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A stackable inventory system where the pet can store their consumable items.
/// Currently limited to just fruits
/// 
/// TO DO:	Now that fruit types don't refer to the same instance of fruit, I need a new method of comparing whether two fruits
/// 		have the same properties, so I know when to stack them. Or maybe I could just stack them anyways and maintain each
/// 		individual fruit's instance.
/// </summary>
public class Inventory : MonoBehaviour 
{
	//List<Fruit> myFruits = new List<Fruit>();

	
	Dictionary<Fruit, int> myFruits = new Dictionary<Fruit, int>()
	{
		
	};
	
	public Dictionary<Fruit, int> GetFruits()
	{
		return myFruits;
	}
	
	public void AddFruit(Fruit fruit)
	{	
		if (myFruits.ContainsKey(fruit))
		{
			myFruits[fruit]++;	
		}
		else
		{
			myFruits.Add(fruit, 1);	
		}
	}
	
	public void TakeFruit(Fruit fruit)
	{
		if (myFruits.ContainsKey(fruit))
		{
			myFruits[fruit]--;	
			
			if (myFruits[fruit] == 0)
			{
				myFruits.Remove(fruit);	
			}
		}
	}
}
