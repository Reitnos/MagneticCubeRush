using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState :  INPCState
{
    public INPCState ChangeState(NPCBomb_StateManager npc)
    {
        if (npc.navAgent == null)
            npc.navAgent = npc.GetComponent<NavMeshAgent>();

        MoveToPlayer(npc);

        if (!npc.attackTarget.activeSelf)
            return npc.wanderState;
        else
            return npc.attackState;
    }
    private void MoveToPlayer(NPCBomb_StateManager npc)
    {
        if (npc.navAgent.destination != npc.attackTarget.transform.position)
            npc.navAgent.SetDestination(npc.attackTarget.transform.position);
    }
}
