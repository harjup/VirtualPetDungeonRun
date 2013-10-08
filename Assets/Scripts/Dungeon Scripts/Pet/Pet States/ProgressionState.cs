using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the pet's path as they progress through the dungeon.
/// Currently uses a placeholder node system where the pet simply travels to one node to the next, until they reach the end
/// </summary>
public class ProgressionState : PetState
{
	private const string stateName = "Progressing";
	private const string transitionToPOI = "Spot Point of Interest";
	private const string transitionToNoEnergy = "Energy Depleted";
	bool newLevel = true;
	
	//Pathfinding
	PathNodeContainer p;
	GameObject currentNode;
	
	[SerializeField]
	int nodeIndex;
	
	
	public GameObject petObject; //Pet Gameobject

	
	
	public override string GetName()
	{
		return stateName;
	}

	public override void Run()
	{
		Progress();
		CheckForPointsOfInterest();
	}
	
	//While there are no points of interest, go to the next waypoint until you reach the end
	void Progress()
	{
		if (newLevel)
		{
			p = GameObject.Find("PathNodeContainer").GetComponent<PathNodeContainer>();
			petObject.transform.position = p.startNode.transform.position;
			nodeIndex = 0;
			newLevel = false;
			
			currentNode = p.pathNodes[nodeIndex];
		}
		
		
		WalkToNextNode();
		
		
		
		float proximity = (petObject.transform.position - currentNode.transform.position).magnitude;
		
		if (proximity < .5f)
		{
			if (currentNode == p.endNode)
			{
				//Go to an end of level state and tell the dungeon state machine you got to the end
			}
			else
			{
				nodeIndex+=1;	
			}
			
			
			if (p.pathNodes.Count <= nodeIndex)
			{
				currentNode = p.endNode;	
			}
			else
			{
				currentNode = p.pathNodes[nodeIndex];
			}
		}
		
		//Starting from the start node, walk from one node to the next until you reach the end node
		
		//Walk speed is determined by speed stat
		//Decrement energy
	}
	
	void WalkToNextNode()
	{
		if (myPet.DrainEnergy())
		{
			iTween.MoveUpdate(petObject, iTween.Hash("position", currentNode.transform.position));
		}
		else
		{
			//Go to no energy state	
			PlayMakerFSM.BroadcastEvent(transitionToNoEnergy);
		}
		
	}
	
	void CheckForPointsOfInterest()
	{
		//If there's an accessible POI in view, approach it
		if (myPet.GetCurrentPOI())
		{
			PlayMakerFSM.BroadcastEvent(transitionToPOI);			
		}
		
	}
	
}
