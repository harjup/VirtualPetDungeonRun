using UnityEngine;
using System.Collections;

public interface IPetCombat
{
	void StartTurn();
	void EndTurn();
	
	void MoveToPosition(Vector3 target);	//Have pet move to a given position
	bool isFinishedMoving();				//Return whether the pet has reached the target position
	int RollStat(Stat.type requestedStat);	//Returns a roll for the given stat, determined based on their level
	
	void RequestAnim(string anim);			//Request a specific animation for the pet to play
}
