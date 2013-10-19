using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class TypesOfFruit 
{
	//Have a simple dictionary that contains all the different types of fruit that can be spawned
	//Maybe it'll eventually be stored externally or some grabage
	
	//TO DO: 	GetFruit() returns the same instance of each Fruit. Need to make it return a unique instance,
	//			either through a cloning method or a factory object.
	
	public enum fruits 
	{
		StrongFruit,
		StrongerFruit,
		SpeedFruit,
		SpeedyFruit
	};
	
	//When the type is not specified...
	public static Fruit defaultFruit = new Fruit("Default Fruit", Stat.type.power, 1, 1, 1);
	
	//Associates each fruit type with a set of properties
	static Dictionary<fruits, Fruit> fruitTypes = new Dictionary<fruits, Fruit>()
	{
		{fruits.StrongFruit, 	new Fruit("StrongFruit", Stat.type.power, 10, 10f, 10)},
		{fruits.StrongerFruit, 	new Fruit("StrongerFruit", Stat.type.power, 20, 10f, 15)},	
		{fruits.SpeedFruit, 	new Fruit("SpeedFruit", Stat.type.speed, 10, 20f, 10)},
		{fruits.SpeedyFruit, 	new Fruit("SpeedyFruit", Stat.type.speed, 20, 20f, 15)}
	};
	
	//Returns a fruit of the given type
	public static Fruit GetFruit(fruits f)
	{
		return fruitTypes[f].GetClone();
	}
	
	
	
	//Returns a random fruit
	public static Fruit GetRandomFruit()
	{
		System.Array a = System.Enum.GetValues(typeof(fruits));
		
		return fruitTypes[(fruits)a.GetValue(Random.Range(0,a.Length))].GetClone();
	}
	
	
}
