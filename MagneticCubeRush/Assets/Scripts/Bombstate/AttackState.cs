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

        MoveToPlayer(npc);
        distanceToExplosion = (npc.player.transform.position - npc.gameObject.transform.position).magnitude;
        
        if (distanceToExplosion < npc.explosionDistance) // if bomb is close enough to player, go to explosion state.
            return npc.explosionState;
        else
            return npc.attackState;
    }
    private void MoveToPlayer(NPCBomb_StateManager npc)
    {
        if (npc.navAgent.destination != npc.attackTarget.transform.position)
            npc.navAgent.SetDestination(npc.attackTarget.transform.position);
    }
}
