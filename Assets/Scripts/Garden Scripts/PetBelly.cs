using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PetBelly : MonoBehaviour 
{
	List<Fruit> fruitList = new List<Fruit>();
	int bellyCapacity = 100;
	
	
	
	//If there is room, eat the given fruit
	//Returns whether the fruit was eaten
	public bool eatFruit(Fruit f)
	{
		if ((getBellyFullness() + f.getBellyVal()) > bellyCapacity)
		{
			return false;
		}
		
		fruitList.Add(f);
		Debug.Log("Ate the fruit, now " + getBellyFullness() + " out of " + bellyCapacity + " full");
		return true;
	}
	
	int getBellyFullness()
	{
		int fullness = 0;
		
		foreach(Fruit f in fruitList)
		{
			fullness += f.getBellyVal();	
		}
		
		return fullness;
	}
	
	public Fruit getLastFruitEaten()
	{
		return fruitList[fruitList.Count - 1];
	}

	
	public float getMaxEnergy()
	{
		float maxEnergy = 0f;
		
		foreach(Fruit f in fruitList)
		{
			maxEnergy += f.getEnergy();	
		}
		
		return maxEnergy;
	}
	
	//Remove the specified fruit, called once the fruit is used up.
	//Returns whether there's any more fruit to use
	public bool removeFruit(Fruit f)
	{
		fruitList.Remove(f);
		
		if (fruitList.Count == 0)
		{
			return false;	
		}
		
		return true;
	}
	
}
