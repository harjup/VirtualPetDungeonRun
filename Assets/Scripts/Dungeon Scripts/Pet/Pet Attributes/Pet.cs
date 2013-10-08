using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pet : MonoBehaviour, IPet 
{
	PetFieldOfView FOV;
	
	List<Stat> stats = new List<Stat>();
	
	[SerializeField]
	float myEnergy;
	
	void Start () 
	{
		FOV = transform.FindChild("PetFOV").GetComponent<PetFieldOfView>();
		
		stats.Add(new Stat(Stat.type.power));
		stats.Add(new Stat(Stat.type.speed));	
	}
	
	
	//Returns the current POI if any in the FOV script
	public GameObject GetCurrentPOI()
	{
		return FOV.GetTopItem();
	}
	
	public int GetAttribute(Stat.type type)
	{
		foreach (Stat s in stats)
		{
			if (s.GetStatType() == type)
				return s.GetLevel();
		}
		
		return -1;
	}
	
	public GameObject GetPetObject()
	{
		return this.gameObject;	
	}
	
	public bool DrainEnergy()
	{
		if (myEnergy > 0)
		{
			myEnergy -= Time.deltaTime;
		}
		else
		{
			//Switch to energy depleted state
			return false;
		}
		
		return true;
	}
	
	public void AddEnergy(int amount)
	{
		myEnergy += amount;	
	}
	
}
