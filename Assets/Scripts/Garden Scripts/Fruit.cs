using UnityEngine;
using System.Collections;

/// <summary>
/// Describes all the properties a consumable fruit holds. May hold an ability as well.
/// </summary>
public class Fruit
{
	Stat.type myType;
	int xp;
	float energy;
	int bellyValue;
	
	public Fruit(Stat.type _mytype, int _xp, float _energy, int _bellyValue)
	{
		myType = _mytype;
		xp = _xp;
		energy = _energy;
		bellyValue = _bellyValue;
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
