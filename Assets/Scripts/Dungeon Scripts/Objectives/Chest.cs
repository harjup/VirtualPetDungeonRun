using UnityEngine;
using System.Collections;

public class Chest : Objective 
{
	bool waitingForPet = false;
	
	public GameObject petInitialPosition;
	public GameObject treasureSpawn;
	
	public override void Init(IPetCombat myPet)
	{
		myPetCombat = myPet;
		myPetCombat.MoveToPosition(petInitialPosition);
		waitingForPet = true;
	}
	
	public override void Run()
	{
		if (waitingForPet)
		{
			//When the pet has finished moving, set waiting for pet to false
			waitingForPet = !myPetCombat.isFinishedMoving();
		}
		else
		{
			OpenChest();
		}
	}
	
	void OpenChest()
	{
		transform.localScale = new Vector3(1f,.5f,1f);
		transform.position = new Vector3(
			transform.position.x, 
			transform.position.y - .5f, 
			transform.position.z);
	
		GameObject.Instantiate(treasureSpawn, transform.position + Vector3.left * 2f, Quaternion.identity);
		GameObject.Instantiate(treasureSpawn, transform.position + Vector3.right * 2f, Quaternion.identity);
		
		tag = "Untagged";
		
		myPetCombat.ObstacleComplete();
	}
	
	
}
