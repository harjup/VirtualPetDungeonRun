using UnityEngine;
using System.Collections;

/// <summary>
/// Describes all the properties a consumable fruit holds. May hold an ability as well.
/// </summary>
public class Fruit
{
	string name;
	Stat.type myType;
	int xp;
	float energy;
	int bellyValue;
	
	
	public Fruit(string _name, Stat.type _mytype, int _xp, float _energy, int _bellyValue)
	{
		name = _name;
		myType = _mytype;
		xp = _xp;
		energy = _energy;
		bellyValue = _bellyValue;
	}
	
	
	public string GetName()
	{
		return name;
	}
	
	public Stat.type getType()
	{
		return myType;
	}
	
	public int getXP()
	{
		return xp;
	}
	
	public float getEnergy()
	{
		return energy;
	}
	
	public int getBellyVal()
	{
		return bellyValue;
	}
	
	public bool useEnergy(float amountUsed)
	{
		energy -= amountUsed;
		
		if (energy <=0)
		{
			return false;	
		}
		
		return true;
	}
}
