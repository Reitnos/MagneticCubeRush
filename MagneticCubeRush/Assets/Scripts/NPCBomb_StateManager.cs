using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBomb_StateManager : MonoBehaviour
{
    [SerializeField]private string currentStateName;
    private INPCState currentState;
    public WanderState wanderState = new WanderState();
    public AttackState attackState = new AttackState();

    public NavMeshAgent navAgent;
    public Vector3 nextLocation;

    public GameObject attackTarget;
    
    public float wanderDistance = 10f;
    public float attackDistance = 25f;
    public GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
        currentState = wanderState;
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.ChangeState(this);
        currentStateName = currentState.ToString();
    }
}
