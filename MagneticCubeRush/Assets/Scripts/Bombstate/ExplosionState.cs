using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ExplosionState : INPCState
{
    // this is a final state so it will simply invoke an action 
    // letting every subscriber to know that bomb has exploded.
    public event Action HasExploded;
    public INPCState ChangeState(NPCBomb_StateManager npc)
    {
        if (npc.navAgent == null)
        {
            npc.navAgent = npc.GetComponent<NavMeshAgent>();
            npc.nextLocation = npc.transform.position;

        }

        BombExploded();
        return null;

    }

    public void BombExploded()
    {
        HasExploded?.Invoke();
    }
}

