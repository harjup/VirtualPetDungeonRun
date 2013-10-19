using UnityEngine;
using System.Collections;

public class PetCollectingFruit : MonoBehaviour 
{
	PetFieldOfView myFOV;
	
	GameObject currentTarget;
	
	Inventory myInventory;
	
	// Use this for initialization
	void Start () 
	{
		myFOV = transform.FindChild("FOV").GetComponent<PetFieldOfView>();
		myInventory = GameObject.Find("PetGarden").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentTarget != myFOV.GetTopItem() && myFOV.GetTopItem())
		{
			currentTarget = myFOV.GetTopItem();
		
			
			Approach();
		}
		
		if (currentTarget)
		{
			if (Vector3.Distance(transform.position, currentTarget.transform.position) < 1.5f)
			{
				CollectFruit();
			}
		}
	}
	
	
	void Approach()
	{
		Vector3 targetPosition = new Vector3(
				currentTarget.transform.position.x,
				transform.position.y,
				currentTarget.transform.position.z
				);
		
		iTween.MoveTo(this.gameObject, iTween.Hash("position", targetPosition, "time", 1f, "oncomplete", "Approach"));
	}
	
	void CollectFruit()
	{
		if (currentTarget.tag != "Untagged")
		{			
			iTween.Stop();		
			
			myInventory.AddFruit(currentTarget.GetComponent<Collectable>().GetMyFruit());
			currentTarget.tag = "Untagged";
			currentTarget.transform.localScale = new Vector3(.3f,.3f,.3f);
		}
	}
	
}
