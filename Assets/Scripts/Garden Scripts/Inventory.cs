using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
