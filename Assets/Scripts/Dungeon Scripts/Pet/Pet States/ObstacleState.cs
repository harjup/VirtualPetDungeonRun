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
	
	float defaultSpeed = 1f;
	
	Objective currentObstacle;
	Objective newObstacle;
	
	public override string GetName()
	{
		return stateName;
	}
	
	public override void Init()
	{
		newObstacle = myPet.GetCurrentPOI().GetComponent<Objective>();
		
		if(newObstacle != currentObstacle)
		{
			currentObstacle = newObstacle;
			currentObstacle.Init(this as IPetCombat);
		}
	}
	
	public override void Run()
	{	
		currentObstacle.Run();
	}
	
	
	
	
	public void MoveToPosition(GameObject target)
	{
		MoveToPosition(target, defaultSpeed);
	}
	public void MoveToPosition(GameObject target, float speed)
	{
		GameObject myPetObject = myPet.GetPetObject();
		
		//Remove any currently ongoing movement commands
		iTween.Stop(myPetObject);
		
		if (Vector3.Distance(myPetObject.transform.position, target.transform.position) < 1.2f)
		{
			//Ignore command
		}
		else
		{
			myPet.MoveToPosition(target, speed);
			//iTween.MoveTo(myPetObject, iTween.Hash("position", target, "speed", speed));	
			//myPet.MoveToPosition(
		}
		
		
	}
	
	public bool isFinishedMoving()	
	{
		if (iTween.Count(myPet.GetPetObject()) == 0)
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
	
	public void UseEnergy(float amount)
	{
		if (myPet.DrainEnergy(amount))
		{
			
		}
		else
		{
			PlayMakerFSM.BroadcastEvent(transitionToNoEnergy);
		}
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
	
	public void CollectItem(Fruit fruit)
	{
		myPet.CollectItem(fruit);
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
