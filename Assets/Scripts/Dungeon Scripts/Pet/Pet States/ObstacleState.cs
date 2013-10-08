using UnityEngine;
using System.Collections;

/// <summary>
/// State for dealing with an obstacle, will likely encompass all obstacles (combat, treasure, etc)
/// 
/// TO DO:	Pass an attribute object into the obstacle for interaction, perhaps even a set of all the pet's attributes so it can bestow XP
/// 		Listen for the pet running out of energy and switch to the appropriate state
/// </summary>
public class ObstacleState : PetState
{
	private const string stateName = "Obstacle";
	private const string transitionToCelebrate = "Complete";
	private const string transitionToNoEnergy = "Energy Depleted";
	
	public override string GetName()
	{
		return stateName;
	}

	public override void Run()
	{
		int petStat = myPet.GetAttribute(Stat.type.power); 	//Get the Pet's associated numbers
		
		Obstacle currentObstacle = myPet.GetCurrentPOI().GetComponent<Obstacle>();
		
		
		
		if (currentObstacle.ApplySkill(petStat))	//Run a function to determine the pet's progress
		{
			//If the pet completes the objective then switch to Celebrate state
			PlayMakerFSM.BroadcastEvent(transitionToCelebrate);
			
		}
		
		//If the pet runs out of energy, switch to the out of energy state
		if (!myPet.DrainEnergy())
		{
			//Go to no energy state
			PlayMakerFSM.BroadcastEvent(transitionToNoEnergy);
		}
	}
}
