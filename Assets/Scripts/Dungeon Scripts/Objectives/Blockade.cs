using UnityEngine;
using System.Collections;

public class Blockade : Objective 
{
	bool myTurn = false;
	int health = 10;
	
	float energyCost = 1f;
	
	//IPetCombat myPetCombat;
	
	public GameObject petPosition;
	
	bool waitingForPet = false;
	
	public override void Init(IPetCombat myPet)
	{
		//List of stuff needs to be run before starting the interaction proper.
		myPetCombat = myPet;
		myPetCombat.MoveToPosition(petPosition);
		waitingForPet = true;
		//Pet needs to move to the correct spot for interaction
		//Any animations need to finish playing
		
		//Waits until everything is finished, and then transitions to main loop
	}
	
	public override void Run()
	{
		if (waitingForPet)
		{
			waitingForPet = !myPetCombat.isFinishedMoving();
		}
		else
		{
			RunTurnOrder();	
		}
		
	}
	
	
	void RunTurnOrder()
	{
		if (!myTurn)
		{
			//Ask the player for a roll with the requested stat
			int roll = myPetCombat.RollStat(Stat.type.power);
			
			//Apply the roll's damage to self.
			//Returns false if you've run out of health
			if (!ApplyDamage(roll))
			{
				//Get killed
				//Play an is-killed animation.
				this.transform.localScale = new Vector3(1f, .5f, 1f);
				
				//When finished with that, tell the pet to switch to celebration state and move on
				myPetCombat.ObstacleComplete();
				
				//Clean up by untagging self
				CleanUp();
			}
			myPetCombat.RequestAnim("theAnimation");
			myPetCombat.UseEnergy(energyCost);
			
			iTween.PunchPosition(this.gameObject, iTween.Hash("amount", new Vector3(0f,2f,0f), "time", 1f, "onComplete", "EndTurn", "delay", .1f));
			
			//Let the pet know what type of animation to play and apply damage.
			
			
			//Play damage animation when hit occurs. (Maybe that should occur between animation managers since they know their timings)
			
			
			myTurn = true;
		}
		else
		{
			//Roll for randomly falling apart or something, blockades don't do a lot on their own
			Debug.Log("BlockadeTurn");
			//myTurn = false;
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
	
	
	void EndTurn()
	{
		myTurn = false;
	}
	
	//Runs cleanup upon completion of obstacle
	void CleanUp()
	{
		this.tag = "Untagged";
	}
}
