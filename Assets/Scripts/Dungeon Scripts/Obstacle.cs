using UnityEngine;
using System.Collections;

/// <summary>
/// Placeholder for interactable objects the pet will run into on their dungeoning career
/// </summary>
public class Obstacle : MonoBehaviour 
{
	string requiredSkill = "skill";
	int health = 10;
	
	//Returns the skill that needs to be used on the given obstacle
	public string GetRequiredSkill()
	{
		return requiredSkill;	
	}
	
	//Applies stat against obstacle, input will eventually be a stat object
	public bool ApplySkill(int level)
	{
		health -= level;
		
		if (health <= 0)
		{
			//This attack overcame the object
			Completed();
			return true;
		}
		
		//This attack didn't overcome the object
		return false;
	}
	
	//Runs cleanup upon completion of obstacle
	void Completed()
	{
		this.tag = "Untagged";
		this.transform.localScale = new Vector3(1f, .5f, 1f);
	}
	
}
