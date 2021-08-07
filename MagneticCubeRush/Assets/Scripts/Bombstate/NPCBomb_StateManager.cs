using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBomb_StateManager : MonoBehaviour
{
    // State Manager to control the NPC states and behaviours.
    private INPCState currentState;
    public WanderState wanderState = new WanderState();
    public AttackState attackState = new AttackState();
    public ExplosionState explosionState = new ExplosionState();

    public NavMeshAgent navAgent;
    public Vector3 nextLocation;

    public GameObject attackTarget;
    
    public float wanderDistance = 5f;
    public float attackDistance = 15f;
    public float explosionDistance = 3f;
    
    public GameObject player;
    private void OnEnable()
    {
        player = GameObject.Find("Player");
        currentState = wanderState;
        navAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        currentState = currentState.ChangeState(this);
       
    }
}
