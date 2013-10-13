using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour 
{
	Fruit myFruit;
	
	public string debugFruitType;
	public string debugXPValue;
	
	public void Init(Fruit _myFruit)
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
