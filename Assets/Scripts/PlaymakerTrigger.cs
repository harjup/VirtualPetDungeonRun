using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaymakerTrigger : MonoBehaviour 
{
	
	PlayMakerFSM DungeonFSM;
	
	// Use this for initialization
	void Start () 
	{
		PlayMakerFSM.BroadcastEvent("Startup Done");
		
		foreach (PlayMakerFSM fsm in PlayMakerFSM.FsmList)
		{
			if (fsm.name == "DungeonSM")
			{
				DungeonFSM = fsm;
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (DungeonFSM != null)
		{
			StateManager();
		}
	}
	
	
	void StateManager()
	{
		string activeStateName = DungeonFSM.ActiveStateName;
		string eventToBroadcast = "";
		
		GameObject dungeonStates = GameObject.Find("DungeonStates");
		Object[] oStates = dungeonStates.GetComponents(typeof(IState));
		
		List<IState> states = new List<IState>();
		foreach (object o in oStates)
		{
				states.Add(o as IState);
		}
		
		
		IState currentState = null;
		
		
		foreach (IState s in states)
		{
			if (s.GetName() == activeStateName)
			{
				currentState = s;	
			}
		}
		
		if (currentState != null)
		{
			currentState.Run();	
		}
	}
}
