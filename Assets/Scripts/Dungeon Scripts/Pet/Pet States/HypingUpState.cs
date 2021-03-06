﻿using UnityEngine;
using System.Collections;

public class HypingUpState : PetState
{
	private const string stateName = "Hyping Up";
	private const string transitionToProgressing = "Countdown Complete";
	
	public override string GetName()
	{
		return stateName;
	}
	
	public override void Init()
	{
		iTween.MoveTo(myPet.GetPetObject(), iTween.Hash("y", 1f, "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.easeOutQuad, "time", .1f));
	}

	public override void Run()
	{	
		//Listen for when to play hype up animation, as well as intensity of animation
		//Listen for when to move on to progression
	}
}
