using UnityEngine;
using System.Collections;

/// <summary>
/// State for dealing with an obstacle, will likely encompass all obstacles (combat, treasure, etc)
/// 
/// TO DO:	Pass an attribute object into the obstacle for interaction, perhaps even a set of all the pet's attributes so it can bestow XP
/// 		There's a bug where the pet will randomly get stuck in this state, possibly fixed
/// </summary>
public class ObstacleState : PetState, IPetCombat
{
	private const string stateName = "Obstacle";
	private const string transitionToCelebrate = "Complete";
	private const string transitionToNoEnergy = "Energy Depleted";
	
	bool isMyTurn = false;
	int petStat = 0;
	Obstacle currentObstacle;
	
	public override string GetName()
	{
		return stateName;
	}
	
	public override void Init()
	{
		isMyTurn = true;
		currentObstacle = myPet.GetCurrentPOI().GetComponent<Obstacle>();
	}
	
	public override void Run()
	{	
		if (isMyTurn)
		{
			if (currentObstacle.ApplySkill(petStat))	//Run a function to determine the pet's progress
			{
				//If the pet completes the objective then switch to Celebrate state
				PlayMakerFSM.BroadcastEvent(transitionToCelebrate);
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
		
		return level;
	}
	
	public void RequestAnim(string anim)
	{
		iTween.PunchPosition(this.gameObject, new Vector3(1f,0f,1f), 1f);
	}
	
	
	
	//To be deleted when Obstacle_Placeholder is thrown away
	public void StartTurn()
	{
		//turn initialization here
		isMyTurn = true;
		//petStat = myPet.GetAttribute(Stat.type.power);	//Get the Pet's associated numbers
		petStat = 5;
	}
	
	public void EndTurn()
	{
		isMyTurn = false;
		currentObstacle.StartTurn(this);
	}
	
	
}
