using UnityEngine;
using System.Collections;

public abstract class Objective : MonoBehaviour 
{
	protected IPetCombat myPetCombat;
	public abstract void Init(IPetCombat myPet);
	public abstract void Run();
}
