using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState :  INPCState
{
    
    private float distanceToExplosion;
    public INPCState ChangeState(NPCBomb_StateManager npc)
    {
        if (npc.navAgent == null)
            npc.navAgent = npc.GetComponent<NavMeshAgent>();

        MoveToPlayer(npc); // face to player and run to it.
        return CheckAndChangeState(npc); // if close enough change to explosion state.
    }

    private INPCState CheckAndChangeState(NPCBomb_StateManager npc)
    {
        distanceToExplosion = (npc.player.transform.position - npc.gameObject.transform.position).magnitude;

        if (distanceToExplosion < npc.explosionDistance)
            return npc.explosionState;
        else
            return npc.attackState;
    }

    private void MoveToPlayer(NPCBomb_StateManager npc)
    {
        if (npc.navAgent.destination != npc.attackTarget.transform.position)
            npc.navAgent.SetDestination(npc.attackTarget.transform.position);
        npc.navAgent.speed = 12f; // make it run
    }
    
}
