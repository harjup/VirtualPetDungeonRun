using UnityEngine;
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
	
	
	
	
	//Returns the name of the current state script
	public override string GetName()
	{
		return stateName;
	}
	
	//When state is active, called every frame
	public override void Run()
	{
		//Let's just abritrarily add some energy back
		myPet.AddEnergy(1);
		
		//Transition back to the state that was previously running
		PlayMakerFSM.BroadcastEvent(stateTransitions[previousState]);
	}
	
	public void SetPreviousState(string state)
	{
		previousState = state;
	}
	
}
