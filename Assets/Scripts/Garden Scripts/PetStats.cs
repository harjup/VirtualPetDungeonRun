using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Container for holding the pet's various stats
/// </summary>
public class PetStats : MonoBehaviour 
{
	void Start()
	{
		GameObject.DontDestroyOnLoad(this);	
	}
	
	
	Dictionary<Stat.type, Stat> Stats = new Dictionary<Stat.type, Stat>()
	{
		{Stat.type.power, new Stat(Stat.type.power, 1, 0)},
		{Stat.type.speed, new Stat(Stat.type.speed, 1, 0)}
	};
	
	public void AddXP(Stat.type myType, int xpAmount)
	{
		Stats[myType].addXP(xpAmount);
	}
	
	public void AddXP(Fruit fruit)
	{
		Stats[fruit.getType()].addXP(fruit.getXP());
	}
	
	public int GetLevel(Stat.type myType)
	{
		return Stats[myType].GetLevel();	
	}
}
