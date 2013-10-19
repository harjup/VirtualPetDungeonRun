using UnityEngine;
using System.Collections;

public interface IPetCombat
{
	void StartTurn();
	void EndTurn();
	
	void MoveToPosition(GameObject target);					//Have pet move to a given position at default speed
	void MoveToPosition(GameObject target, float speed);	//Have pet move to a given position at a given speed
	bool isFinishedMoving();				//Return whether the pet has reached the target position
	int RollStat(Stat.type requestedStat);	//Returns a roll for the given stat, determined based on their level
	void UseEnergy(float amount);
	
	
	void RequestAnim(string anim);			//Request a specific animation for the pet to play
	void CollectItem(Fruit fruit);
	
	void ObstacleComplete();
}
