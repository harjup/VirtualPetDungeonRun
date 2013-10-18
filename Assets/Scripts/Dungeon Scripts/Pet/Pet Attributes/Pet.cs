﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pet : MonoBehaviour, IPet 
{
	PetFieldOfView FOV;
	
	//List<Stat> stats = new List<Stat>();
	
	[SerializeField]
	float myEnergy;
	
	PetStats petStats;
	PetBelly petBelly;
	Inventory petInventory;
	
	void Start () 
	{
		FOV = transform.FindChild("PetFOV").GetComponent<PetFieldOfView>();
		
		petStats = GameObject.Find("PetGarden").GetComponent<PetStats>();
		petBelly = GameObject.Find("PetGarden").GetComponent<PetBelly>();
		petInventory = GameObject.Find("PetGarden").GetComponent<Inventory>();
		
		myEnergy = petBelly.GetMaxEnergy();
	}
	
	
	//Returns the current POI if any in the FOV script
	public GameObject GetCurrentPOI()
	{
		return FOV.GetTopItem();
	}
	
	public GameObject GetPetObject()
	{
		return this.gameObject;	
	}
	
	public int GetStatLevel(Stat.type type)
	{
		return petStats.GetLevel(type);
	}
	
	public void CollectItem(Fruit fruit)
	{
		petInventory.AddFruit(fruit);
	}
	
	public bool DrainEnergy()
	{
		
		/*
		if (myEnergy > 0)
		{
			myEnergy -= Time.deltaTime;
		}
		else
		{
			//Switch to energy depleted state
			return false;
		}
		*/
		
		Fruit currentFruit = petBelly.GetLastFruitEaten();
		
		//Debug to check energy level
		myEnergy = currentFruit.getEnergy();
		
		if (currentFruit.useEnergy(Time.deltaTime))
		{
			return true;
		}
		
		//If the fruit's energy is all used up...
		petStats.AddXP(currentFruit);
		
		if (petBelly.RemoveFruit(currentFruit))
		{
			return true;
		}
		
		return false;
	}
	
	public void AddEnergy(int amount)
	{
		myEnergy += amount;	
	}
	
}
