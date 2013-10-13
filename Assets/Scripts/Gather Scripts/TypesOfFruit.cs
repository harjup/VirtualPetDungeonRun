using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class TypesOfFruit 
{
	//Have a simple dictionary that contains all the different types of fruit that can be spawned
	//Maybe it'll eventually be stored externally or some grabage
	
	public enum fruits 
	{
		StrongFruit,
		StrongerFruit,
		SpeedFruit,
		SpeedyFruit
	};
	
	static Dictionary<fruits, Fruit> fruitTypes = new Dictionary<fruits, Fruit>()
	{
		{fruits.StrongFruit, 	new Fruit(Stat.type.power, 10, 10f, 10)},
		{fruits.StrongerFruit, 	new Fruit(Stat.type.power, 20, 10f, 15)},	
		{fruits.SpeedFruit, 	new Fruit(Stat.type.speed, 10, 20f, 10)},
		{fruits.SpeedyFruit, 	new Fruit(Stat.type.speed, 20, 20f, 15)}
	};
	
	public static Fruit GetFruit(fruits f)
	{
		return fruitTypes[f];
	}
	
}
