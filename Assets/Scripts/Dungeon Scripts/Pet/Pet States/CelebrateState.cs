using UnityEngine;
using System.Collections;

/// <summary>
/// Pet pauses to celebrate a completed objective before continuing on
/// 
/// TO DO:	Have the pet play a celebration animation when finished
/// 
/// </summary>
public class CelebrateState : PetState
{
	private const string stateName = "Celebrate";
	private const string transitionToProgressing = "Done Celebrating";
	
	float placeHolderTimer = 1f;
	
	public override string GetName()
	{
		return stateName;
	}
	 
	public override void Run()
	{
		placeHolderTimer -= Time.deltaTime;
		
		if (placeHolderTimer <= 0f)
		{
			placeHolderTimer = 1f;
			PlayMakerFSM.BroadcastEvent(transitionToProgressing);	
		}
		
	}
	
}
