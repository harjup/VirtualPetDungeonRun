using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	List<Fruit> myFruits = new List<Fruit>();
	
	public List<Fruit> GetFruits()
	{
		return myFruits;
	}
	
	public void AddFruit(Fruit fruit)
	{
		myFruits.Add(fruit);
	}
	
	public void TakeFruit(Fruit fruit)
	{
		myFruits.Remove(fruit);	
	}
}
