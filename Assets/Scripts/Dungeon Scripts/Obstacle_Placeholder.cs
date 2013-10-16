using UnityEngine;
using System.Collections;

/// <summary>
/// Placeholder for interactable objects the pet will run into on their dungeoning career
/// </summary>
public class Obstacle_Placeholder : Obstacle
{
	//string requiredSkill = "skill";
	//int health = 10;
	
	IPetCombat myOpponent;
	
	void Start()
	{
		health = 10;		
	}
	
	//Returns the skill that needs to be used on the given obstacle
	public override Stat.type GetRequiredStat()
	{
		return Stat.type.power;	
	}
	
	public override void StartTurn(IPetCombat opponent)
	{
		isMyTurn = true;
		iTween.PunchPosition(this.gameObject, iTween.Hash("amount", new Vector3(0f,2f,0f), "time", 1f, "onComplete", "EndTurn"));
		myOpponent = opponent;
	}
	
	public override void EndTurn()
	{
		isMyTurn = false;
		myOpponent.StartTurn();
	}
	
	void Update()
	{
		if (isMyTurn)
		{
			//Any logic that needs to get called every frame
		}
	}
	
	
	//Applies stat against obstacle, input will eventually be a stat object
	public override bool ApplySkill(int level)
	{
		health -= level;
		
		if (health <= 0)
		{
			//This attack overcame the object
			Completed();
			return true;
		}
		
		//This attack didn't overcome the object
		return false;
	}
	
	//Runs cleanup upon completion of obstacle
	void Completed()
	{
		this.tag = "Untagged";
		this.transform.localScale = new Vector3(1f, .5f, 1f);
	}
	
}
