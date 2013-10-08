using System.Collections;

/// <summary>
/// Describes a pet's proficiency in a given discipline
/// Can be leveled up, given enough experience
/// </summary>
public class Stat 
{
	//All the posslbe types for a given stat
	public enum type {power, speed};
	
	int level;
	int currentXP;
	int xpToNextLevel;
	
	type myType;
	
	public Stat(type _myType, int _level = 1, int _currentXP = 0)
	{
		level = _level;
		currentXP = _currentXP;
		myType = _myType;
	}
	
	public int GetLevel()
	{
		return level;	
	}
	
	public type GetStatType()
	{
		return myType;
	}
	
	//Adds experience to stat, checks if this causes a level up
	public bool addXP(int amount)
	{
		currentXP += amount;
		
		if (currentXP >= xpToNextLevel)
		{
			level +=1;
			currentXP -=xpToNextLevel;
			xpToNextLevel = getXPToNextLevel(level);
			return true;
		}
		
		return false;
	}
	
	int getXPToNextLevel(int level)
	{
		return level * 10;
	}
	
}
