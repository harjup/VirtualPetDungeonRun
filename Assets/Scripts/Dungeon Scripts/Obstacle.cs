using UnityEngine;
using System.Collections;

/// <summary>
/// Basic obstacle that pet must interact with
/// </summary>
public abstract class Obstacle : MonoBehaviour 
{
	protected int health;
	protected bool isMyTurn = false;
	
	public abstract bool ApplySkill(int level);
	
	public abstract Stat.type GetRequiredStat();
	public abstract void StartTurn(IPetCombat opponent);	
	public abstract void EndTurn();
}
