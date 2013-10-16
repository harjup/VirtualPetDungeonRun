using UnityEngine;
using System.Collections;

/// <summary>
/// State for dealing with an obstacle. Provides the behaviors nessesary for an obstacle to orchestrate their interaction, through an interface.
/// Logic exists in the current obstacle's run function, which is called every frame in this script's run function.
/// </summary>
public class ObstacleState : PetState, IPetCombat
{
	private const string stateName = "Obstacle";
	private const string transitionToCelebrate = "Complete";
	private const string transitionToNoEnergy = "Energy Depleted";
	
	Blockade currentObstacle;
	
	public override string GetName()
	{
		return stateName;
	}
	
	public override void Init()
	{
		currentObstacle = myPet.GetCurrentPOI().GetComponent<Blockade>();
		
		currentObstacle.Init(this as IPetCombat);
	}
	
	public override void Run()
	{	
		currentObstacle.Run();
		/*
		if (isMyTurn)
		{
			if (currentObstacle.ApplySkill(petStat))	//Run a function to determine the pet's progress
			{
				//If the pet completes the objective then switch to Celebrate state
				
				isMyTurn = true;
			}
			
			//If the pet runs out of energy, switch to the out of energy state
			if (!myPet.DrainEnergy())
			{
				//Go to no energy state
				PlayMakerFSM.BroadcastEvent(transitionToNoEnergy);
			}
			
			EndTurn();
		}
		*/
	}
	
	
	public void MoveToPosition(Vector3 target)
	{
		iTween.MoveTo(this.gameObject, target, 1f);
	}
	public bool isFinishedMoving()	
	{
		if (iTween.Count(this.gameObject) == 0)
		{
			return true;
		}
		
		return false;
	}
	public int RollStat(Stat.type requestedStat)
	{
		int level = myPet.GetStatLevel(requestedStat);
		
		return level * 3;
	}
	
	public void RequestAnim(string anim)
	{
		Debug.Log("Do a punch");
		iTween.PunchPosition(myPet.GetPetObject(), new Vector3(1f,0f,1f), 1f);
	}
	
	public void ObstacleComplete()
	{
		PlayMakerFSM.BroadcastEvent(transitionToCelebrate);
	}
	
	
	//To be deleted when Obstacle_Placeholder is thrown away
	public void StartTurn()
	{
		//turn initialization here
		//isMyTurn = true;
		//petStat = myPet.GetAttribute(Stat.type.power);	//Get the Pet's associated numbers
		//petStat = 5;
	}
	
	public void EndTurn()
	{
		//isMyTurn = false;
		//currentObstacle.StartTurn(this);
	}
	
	
}
