using UnityEngine;
using System.Collections;

public class Combat : Objective 
{



	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public override void Init(IPetCombat myPet)
    {
        myPetCombat = myPet;
        //Begin approaching the pet, and tell the pet to begin approaching self
        //When they meet up, begin combat
    }

    public override void Run()
    {
        //When it is my turn, roll an attack and hit the pet for the amount rolled. Then end my turn
        //When it is the pet's turn, have them roll an attack and hit me for the amount of damage rolled.
    }

    //Takes in a damage amount and applies it to health.
    //If health goes below zero, run death method
    void TakeDamage(int amount)
    {

    }

    //Run death animation, set up a timer for despawning
    //Drop valuables, yield XP to pet
    //Tell pet to go to celebration state
    void Killed()
    {

    }
}
