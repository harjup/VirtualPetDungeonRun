﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OutOfEnergyState : PetState
{
	private const string stateName = "Out of Energy";
	
	private string previousState;
	
	Dictionary<string,string> stateTransitions = new Dictionary<string, string>()
	{
		{"Progressing", "Back to Progress"},
		{"Approach PoI", "Back to Approach"},
		{"Obstacle", "Back to Obstacle"}
		
	};
	
	private const string transitionToLeaveDungeon = "Leave";
	
	
	//Returns the name of the current state script
	public override string GetName()
	{
		return stateName;
	}
	
	//When state is active, called every frame
	public override void Run()
	{
		//If the user consumes an energy item, continue on
		if (Input.GetKey(KeyCode.Z))
		{
			//Let's just abritrarily add some energy back
			myPet.AddEnergy(1);
			
			//Transition back to the state that was previously running
			PlayMakerFSM.BroadcastEvent(stateTransitions[previousState]);
		}
		
		//If the user has no remaining energy items, leave the dungon
		if (Input.GetKey(KeyCode.X))
		{
			PlayMakerFSM.BroadcastEvent(transitionToLeaveDungeon);
		}
	}
	
	public void SetPreviousState(string state)
	{
		previousState = state;
	}
	
}
