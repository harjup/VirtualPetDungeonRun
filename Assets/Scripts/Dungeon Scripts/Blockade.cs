using UnityEngine;
using System.Collections;

public class Blockade : MonoBehaviour 
{
	bool myTurn = false;
	int health = 10;
	
	
	IPetCombat myPet;
	
	void Init()
	{
		//List of stuff needs to be run before starting the interaction proper.
		//Pet needs to move to the correct spot for interaction
		//Any animations need to finish playing
		
		//Waits until everything is finished, and then transitions to main loop
	}
	
	void Main()
	{
		if (!myTurn)
		{
			//Ask the player for a roll with the requested stat
			int roll = myPet.RollStat(Stat.type.power);
			
			//Apply the roll's damage to self.
			if (ApplyDamage(roll))
			{
				//Get killed
			}
			
			//Let the pet know what type of animation to play and apply damage.
			myPet.RequestAnim("theAnimation");
			
			//Play damage animation when hit occurs. (Maybe that should occur between animation managers since they know their timings)
			
			
			myTurn = true;
		}
		else
		{
			//Roll for randomly falling apart or something, blockades don't do a lot on their own
			
			myTurn = false;
		}
	}
	
	
	bool ApplyDamage(int damage)
	{
		health -= damage;
		
		if (health <= 0)
		{
			return false;	
		}
		
		return true;
	}
	
}
