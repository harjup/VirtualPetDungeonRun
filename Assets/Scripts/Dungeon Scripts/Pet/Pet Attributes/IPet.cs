using UnityEngine;

/// <summary>
/// Used to access any data the Pet might be holding
/// </summary>
public interface IPet 
{
	//Returns the pet's current point of interest
	GameObject GetCurrentPOI();
	
	//Get the value for a given attribute
	int GetStatLevel(Stat.type type);
	
	GameObject GetPetObject();
	
	bool DrainEnergy(float amount);
	
	
	void AddEnergy(int amount);
	
	void CollectItem(Fruit fruit);
	
	void MoveToPosition(GameObject target, float speed);
	void StopMoving();
    void PauseMoving();
    void ResumeMoving();
}
