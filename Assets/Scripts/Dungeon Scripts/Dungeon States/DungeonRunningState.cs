using UnityEngine;
using System.Collections;

public class DungeonRunningState : MonoBehaviour, IState
{
	private const string stateName = "DungeonRunning";
	private const string transitionToNeedEnergy = "No Energy";
	private const string transitionToLevelTransition = "Used Stairs";
	
	public string GetName()
	{
		return stateName;
	}
	
	public void Run()
	{	
		//Tell pet to do the dungeon running
		
		//Tell enemies to walk around and engage in combat
		
		
		
		
	}
	
	//Listen for "pet is out of energy" event
	void TransitionOutOfEnergy()
	{
		PlayMakerFSM.BroadcastEvent(transitionToNeedEnergy);
	}
	//Listen for "pet used the stairs" event
	void TransitionUsedTheStairs()
	{
		PlayMakerFSM.BroadcastEvent(transitionToLevelTransition);
	}
	//Listen for "pause" event
	void TransitionPause()
	{
		
	}
}
