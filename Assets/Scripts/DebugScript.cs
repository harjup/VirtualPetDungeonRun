using UnityEngine;
using System.Collections;

public class DebugScript : MonoBehaviour 
{
	
	public int petPowerLevel;
	PetStats pStats;
	
	
	// Use this for initialization
	void Start () 
	{
		pStats = GetComponent<PetStats>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		petPowerLevel = pStats.GetLevel(Stat.type.power);
	}
}
