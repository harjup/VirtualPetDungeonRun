using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Looks at all items within a certain proximity to the pet and ranks them based on priority.
/// </summary>
public class PetFieldOfView : MonoBehaviour 
{
	//Dictionary holding all the tags for points of interest and their associated priorities
	Dictionary<string, int> interestPoints = new Dictionary<string, int>()
	{
		{"Obstacle",1},
		{"Combat", 3},
		{"Treasure", 2},
		{"Stairs", 0},
		{"End Goal", 0}
	};
	
	[SerializeField]
	private List<GameObject> PoIObjects = new List<GameObject>();
	
	//Get the top item that's currently reachable
	public GameObject GetTopItem()
	{
		if (PoIObjects.Count != 0)
		{	
			//Iterate through each item in PoIObjects and
			//return the first item that's reachable
			for (int i = 0; i < PoIObjects.Count; i++) 
			{
				GameObject currentObj = PoIObjects[i];
				
				//If the obstacle is no longer active, remove it from the list
				if (currentObj.tag == "Untagged")
				{
					PoIObjects.RemoveAt(i);
					i--;
					continue;
				}
				
				//If the pet can see the current object, return it
				if (CheckIfAccessible(currentObj))
				{
					return currentObj;
				}
			}
		}
		
		//If no reachable items are found return null
		return null;
	}
	
	//Checks to see if the current item is blocked by another object
	bool CheckIfAccessible(GameObject item)
	{
		RaycastHit hit = new RaycastHit();
		
		if (Physics.Linecast(transform.position, item.transform.position, out hit)) 
		{
	        if (hit.transform.gameObject == item) 
			{
				return true;
	       	}
		}
		
		return false;
	}
	
	
	void OnTriggerEnter(Collider collider)
	{
		GameObject obj = collider.gameObject;
		
		if (!CheckIfAccessible(obj))
		{
			Debug.Log("I can't see " + obj.name);
		}
		
		
		if (interestPoints.ContainsKey(collider.tag) && !PoIObjects.Contains(obj))
		{
			AddItem(obj);
		}
	}
	
	void OnTriggerExit(Collider collider)
	{
		if (interestPoints.ContainsKey(collider.tag))
		{
			PoIObjects.Remove(collider.gameObject);
		}
	}
	
	//When a new item enters the pet's FOV, check its priority and add it to the appropriate spot
	void AddItem(GameObject obj)
	{
		int objPriority = interestPoints[obj.tag];
		
		for (int i = 0; i < PoIObjects.Count; i++) 
		{
			int currentPriority = interestPoints[PoIObjects[i].tag];
			
			if (objPriority > currentPriority)
			{
				PoIObjects.Insert(i, obj);
				return;
			}
		}
		
		PoIObjects.Insert(PoIObjects.Count, obj);
	}
}
