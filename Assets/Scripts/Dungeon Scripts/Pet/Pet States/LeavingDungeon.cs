using UnityEngine;
using System.Collections;

public class LeavingDungeon : PetState 
{
	private const string stateName = "Out of Energy";
	
	public override string GetName()
	{
		return stateName;
	}
	
	public override void Init()
	{
		
	}
	
	public override void Run()
	{
		//display the fact that leaving the dungeon is occuring
		//wait an abritrary amount of time
		//leave dungeon
		Application.LoadLevel("GardenTest");
	}
}
