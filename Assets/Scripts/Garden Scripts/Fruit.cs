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
	float energyMaximum;
	int bellyValue;
	
	
	public Fruit(string _name, Stat.type _mytype, int _xp, float _energy, int _bellyValue)
	{
		name = _name;
		myType = _mytype;
		xp = _xp;
		energy = _energy;
		energyMaximum = _energy;
		bellyValue = _bellyValue;
	}
	
	//Workaround for getting a unique instance of a given fruit
	//May eventually get replaced with a factory implementation
	public Fruit GetClone()
	{
		return new Fruit(name, myType, xp, energy, bellyValue);
	}
	
	public bool CheckIfSame(Fruit f)
	{
		string myProps = name + myType.ToString() + xp + energy + bellyValue;
		string otherProps = f.name + f.getType().ToString() + f.getXP() + f.getEnergy() + f.getBellyVal();
		
		if (myProps == otherProps)
		{
			return true;
		}
		return false;
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
	
	public float getEnergyMax()
	{
		return energyMaximum;
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
