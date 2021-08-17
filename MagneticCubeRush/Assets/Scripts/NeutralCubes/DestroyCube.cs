using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DestroyCube : MonoBehaviour
{
    // make the collected cubes disappear on the collection zone and count them points to the player.
    private Renderer _renderer;
    private NeutralCubeCollect cubeCollect;
    private MoveToPlayer _moveToPlayer;
    private bool finishAction = false;

    private void Start()
    {
        cubeCollect = GetComponent<NeutralCubeCollect>();
        _moveToPlayer = GetComponent<MoveToPlayer>();
        _renderer = GetComponent<Renderer>();
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Detector"))
        {
            BehaviourAfterFinishLine();

            //cubeCollect.DestroyCube();
        }
    }
    */
    private void Update()
    {
        if (_moveToPlayer.distanceToCollector <= 10f && !finishAction)
        {
            BehaviourAfterFinishLine();
        }
        
    }

    private void BehaviourAfterFinishLine()
    {
        _renderer.material.color = Color.yellow;
        _moveToPlayer.NCubeState = MoveToPlayer.NeutralCubeState.Follow_Collector;
        cubeCollect.CollectedByPlayer(1);
        finishAction = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            CheckCubeStateAndIncreaseEnemyScore();
        }
    }

    private void CheckCubeStateAndIncreaseEnemyScore()
    {
        MoveToPlayer moveToPlayer = GetComponent<MoveToPlayer>();
        if (moveToPlayer.NCubeState != MoveToPlayer.NeutralCubeState.Follow_Collector)
        {
            cubeCollect.CollectedByNPC(1);
            cubeCollect.DestroyCube();
        }
    }
}
