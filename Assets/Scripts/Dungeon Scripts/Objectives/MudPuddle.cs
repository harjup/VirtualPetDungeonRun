using UnityEngine;
using System.Collections;

public class MudPuddle : Objective 
{
	public GameObject petInitialPosition;
	public GameObject petGoalPosition;
	
	bool waitingForPet = false;
	
	float timer = 0f;
	float timerMax = 1f;
	
	public override void Init(IPetCombat myPet)
	{
		myPetCombat = myPet;
		myPetCombat.MoveToPosition(petInitialPosition.transform.position);
		timer = 0f;
		waitingForPet = true;
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
		timer -= Time.deltaTime;
		
		if (timer <= 0f)
		{
			timer = timerMax;
			
			float petSpeed = myPetCombat.RollStat(Stat.type.speed)/2f;
			
			myPetCombat.MoveToPosition(petGoalPosition.transform.position, petSpeed);
		}
		
		if (myPetCombat.isFinishedMoving())
		{
			myPetCombat.ObstacleComplete();
			CleanUp();
		}
	}
	
	void CleanUp()
	{
		this.tag = "Untagged";
	}
	
}
