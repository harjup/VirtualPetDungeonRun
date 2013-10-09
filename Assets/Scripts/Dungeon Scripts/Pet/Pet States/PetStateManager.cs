using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// The state manager for the Pet that will eventually hook all its states together
/// </summary>
public class PetStateManager : MonoBehaviour 
{
	PlayMakerFSM PetRunFSM;
	
	IPet currentPet;
	
	
	public enum State
	{
		Hyping_Up,
		Progressing,
		Approach_PoI,
		Obstacle,
		Celebrate,
		Out_of_Energy
	};
	
	
	string[] stateHistory = new string[2];
	string activeStateName;
	List<PetState> states = new List<PetState>();
	
	PetState currentState = null;	//The current state that is being run
	PetState previousState = null; 	//The state that was run last frame
	
	
	// Use this for initialization
	void Start () 
	{
		foreach (PlayMakerFSM fsm in PlayMakerFSM.FsmList)
		{
			if (fsm.name == "PetRunFSM")
			{
				PetRunFSM = fsm;
				break;
			}
		}
		
		//Placeholder for getting the current pet interface
		currentPet = GameObject.Find("Pet").GetComponent(typeof(IPet)) as IPet;
		
		//Initializes the list of available pet states
		if (PetRunFSM != null)
		{
			GameObject petStates = GameObject.Find("PetStates");
			Object[] oStates = petStates.GetComponents(typeof(PetState));
		
			foreach (object o in oStates)
			{
				states.Add(o as PetState);
				(o as PetState).SetMyPet(currentPet); //Sets up all the states to refer to the correct IPet script
			}
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (PetRunFSM != null)
		{
			StateManager();	
		}
	}
	
	void StateManager()
	{
		activeStateName = PetRunFSM.ActiveStateName;
		
		updateStateHistory(activeStateName);
	
		foreach (PetState s in states)
		{			
			if (s.GetName() == activeStateName)
			{
				currentState = s;
			}
		}
		
		//If the state has changed since last frame, run that state's init function
		if (previousState != currentState)
		{
			//Debug.Log("Initializing " + currentState.GetName() + " State");
			currentState.Init();
			previousState = currentState;
		}
		
		
		if (currentState != null)
		{	
			if (currentState.GetType() == typeof(OutOfEnergyState))
			{
				(currentState as OutOfEnergyState).SetPreviousState(getPreviousState());
			}
			
			currentState.Run();
		}
	}
	
	string getPreviousState()
	{
		return stateHistory[1];	
	}
	
	void updateStateHistory(string name)
	{
		if (stateHistory[0] != name)
		{
			stateHistory[1] = stateHistory[0];	
			stateHistory[0] = name;
		}
	}
}
