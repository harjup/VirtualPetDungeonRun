﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Currently attempting to replace IPetState with this so I don't have to implement some methods in every single class
/// </summary>
public abstract class PetState : MonoBehaviour 
{	
	//protected string stateName;
	
	protected IPet myPet;
	
	/* I can't made GetName baked in because I want stateName to be a constant field for each individual class
	public string GetName()
	{
		return stateName;
	}
	*/
	
	public virtual void Init()	//Optional initialization stuff for the state
	{
		
	}
	
	public abstract string GetName();	//Returns the name of the state
	
	public void SetMyPet(IPet _myPet)
	{
		myPet = _myPet;
	}
	
	public abstract void Run();
}
