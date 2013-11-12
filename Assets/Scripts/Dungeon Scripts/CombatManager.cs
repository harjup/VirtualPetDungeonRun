using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatManager : MonoBehaviour
{
    //Teams
    //Turn Order

    void InitCombat(string otherCombatant)
    {
        //When one agent comes in contact with another and neither are in combat, they can initiate combat between each other

        //If a agent stumbles upon an already existing engagement, then it will be added to the corresponding team and turn order determined
    }

    void DetermineTurnOrder()
    {
        //Takes a look at each agent's speed stat and rolls turn order
        //Creates a stack corresponding to each agent's turn
    }

    void GetMembersOfTeam(string team)
    {
        //Allow an agent to look at the currently existing members of a team to determine who to attack, whether to run, any other behavior
    }

    void AttackAgent(string targetAgent, StatBlob stats)
    {
        //The active agent supplies a target to attack and its stats 
        //The target's stats are grabbed, and rolls are made to determine if the attack connects, damage taken, etc
    }
}
