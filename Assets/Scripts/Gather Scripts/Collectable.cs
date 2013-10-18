using UnityEngine;
using System.Collections;

public class Collectable : Objective 
{
	Fruit myFruit = TypesOfFruit.defaultFruit;
	
	public string debugFruitType;
	public string debugXPValue;
	
	public override void Init(IPetCombat myPet)
	{
		myPetCombat = myPet;
	}
	
	public override void Run()
	{
		transform.localScale = new Vector3(.1f,.1f,.1f);
		tag = "Untagged";
		myPetCombat.CollectItem(myFruit);
		myPetCombat.ObstacleComplete();
	}
	
	public void SetFruit(Fruit _myFruit)
	{
		myFruit = _myFruit;
		
		debugFruitType = myFruit.getType().ToString();
		debugXPValue = myFruit.getXP().ToString();
	}
	
	public Fruit GetMyFruit()
	{
		return myFruit;
	}
}
