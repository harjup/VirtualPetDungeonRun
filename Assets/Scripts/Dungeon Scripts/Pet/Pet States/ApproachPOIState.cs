using UnityEngine;
using System.Collections;

/// <summary>
/// When the pet comes across a point of interest, approach it.
/// </summary>
public class ApproachPOIState : PetState
{
	private const string stateName = "Approach PoI";
	private const string transitionToObstacle = "Reach Obstacle";
	private const string transitionToProgression = "Lost Obstacle";
	private const string transitionToNoEnergy = "Energy Depleted";
	
	bool isNewPOI = true;
	
	public GameObject petObject;
	public GameObject targetPOI;
	
	
	public override string GetName()
	{
		return stateName;
	}
	
	public override void Init()
	{
		isNewPOI = true;
	}
	
	public override void Run()
	{
		if (isNewPOI)
		{	
			targetPOI = myPet.GetCurrentPOI();
			//Stop moving, play thinking anim. Then begin approaching current target
			myPet.MoveToPosition(targetPOI, myPet.GetStatLevel(Stat.type.speed));
			
			isNewPOI = false;
		}
		else
		{
			if (myPet.DrainEnergy(Time.deltaTime))
			{
				Approach();
			}
			else
			{
				//Switch to no energy state	
				PlayMakerFSM.BroadcastEvent(transitionToNoEnergy);
			}
		}
	}
	
	void Approach()
	{
		if (targetPOI != myPet.GetCurrentPOI())
		{
			isNewPOI = true;
			//myPet.MoveToPosition(targetPOI, 1f);
		}
		
		if (targetPOI)
		{
			//Walk toward current target
			//iTween.MoveUpdate(petObject, iTween.Hash("position", targetPOI.transform.position, "time", 3f));
			
			//When the target is reached, switch to the state appropriate for interacting with it
			float distance = Vector3.Distance(petObject.transform.position, targetPOI.transform.position);
			
			if (distance < 1.2f)
			{
				PlayMakerFSM.BroadcastEvent(transitionToObstacle);
			}
		}
		else
		{
			PlayMakerFSM.BroadcastEvent(transitionToProgression);
		}
	}
	
}

