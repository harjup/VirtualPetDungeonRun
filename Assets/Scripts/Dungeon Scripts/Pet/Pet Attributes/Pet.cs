using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pet : MonoBehaviour, IPet 
{
	PetFieldOfView FOV;
	
	//List<Stat> stats = new List<Stat>();
	
	GameObject myPetObject;
	
	[SerializeField]
	float myEnergy;
	
	PetStats petStats;
	PetBelly petBelly;
	Inventory petInventory;
	
	void Start () 
	{
		myPetObject = this.gameObject;
		
		FOV = transform.FindChild("PetFOV").GetComponent<PetFieldOfView>();
		
		petStats = GameObject.Find("PetGarden").GetComponent<PetStats>();
		petBelly = GameObject.Find("PetGarden").GetComponent<PetBelly>();
		petInventory = GameObject.Find("PetGarden").GetComponent<Inventory>();
		
		myEnergy = petBelly.GetMaxEnergy();
		
	}
	
	
	//Returns the current POI if any in the FOV script
	public GameObject GetCurrentPOI()
	{
		return FOV.GetTopItem();
	}
	
	public GameObject GetPetObject()
	{
		return this.gameObject;	
	}
	
	public int GetStatLevel(Stat.type type)
	{
		return petStats.GetLevel(type);
	}
	
	public void CollectItem(Fruit fruit)
	{
		petInventory.AddFruit(fruit);
	}
	
	public bool DrainEnergy(float amount)
	{
		Fruit currentFruit = petBelly. GetLastFruitEaten();

	    if (currentFruit == null)
	        return false;

		//Debug to check energy level
		myEnergy = currentFruit.getEnergy();
		
		if (currentFruit.useEnergy(amount))
		{
			return true;
		}
		
		//If the fruit's energy is all used up...
		petStats.AddXP(currentFruit);
		
		//If there's another fruit in line to be used, then continue on
		if (petBelly.RemoveFruit(currentFruit))
		{
			return true;
		}
		
		return false;
	}
	
	public void AddEnergy(int amount)
	{
	    petBelly.EatFruit((new Fruit("Candy", Stat.type.speed, 0, 1f, 0)));
        Debug.Log("eating candy");
	}
	
	//Takes in a gameobject so I have the option to check if the object has moved, and have the pet change course to compensate
	public void MoveToPosition(GameObject target, float speed)
	{
		iTween.Stop(myPetObject);
		
		iTween.MoveTo(myPetObject, iTween.Hash("position", target.transform.position, "speed", speed * 2f, "easetype", iTween.EaseType.linear));
		
		Debug.Log("Moving pet to " + target.name + " at speed " + speed.ToString() + " at postition " + target.transform.position.ToString());
	}
	
    //Currently isn't called by anything
	public void StopMoving()
	{
		iTween.Stop(myPetObject); 
	}

    public void PauseMoving()
    {
        iTween.Pause(myPetObject);
        
    }

    public void ResumeMoving()
    {
        iTween.Resume(myPetObject);
    }

}
