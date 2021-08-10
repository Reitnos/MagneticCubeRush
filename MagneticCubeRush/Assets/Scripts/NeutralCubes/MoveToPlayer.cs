using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{
    public float followPlayerDistance = 10f;
    private Rigidbody rb;
    public float followSpeed = 10f;

    public float destroyRange = 3;
    public float distanceToCollector;


    //   private bool detectedByPlayer = false
 public NeutralCubeState NCubeState = NeutralCubeState.Standing;
   
    private GameObject player;
    private GameObject collector;
    void FixedUpdate()
    {
        Vector3 PlayerDestination = (player.transform.position - this.gameObject.transform.position);
        Vector3 CollectorDestination = (collector.transform.position - this.gameObject.transform.position);
        distanceToCollector = CollectorDestination.magnitude;
        //CanSeePlayer(PlayerDestination);
       /*
        if (detectedByPlayer)
        {
            FollowPlayer(destination);
        }
        */
     
       switch (NCubeState)
       {
           case  NeutralCubeState.Standing:
               CanSeePlayer(PlayerDestination);
               break;
           case NeutralCubeState.Follow_Player:
               FollowPlayer(PlayerDestination);
               break;
           case NeutralCubeState.Follow_Collector:
               FollowCollector(CollectorDestination);
               break;
       }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        collector = GameObject.Find("Collector");
        
    }

    void CanSeePlayer(Vector3 destination)
    {
        float distance = destination.magnitude;
        if (distance < followPlayerDistance)
        {
            Vector3 direction = player.transform.position - transform.position;
            Ray ray = new Ray(transform.position + Vector3.up, direction);


            if (Physics.Raycast(ray, out RaycastHit hit, followPlayerDistance))
            {
                if (hit.collider.gameObject == player)
                {
                    //detectedByPlayer = true;
                    NCubeState = NeutralCubeState.Follow_Player;
                }
            }
        }


    }

    void FollowPlayer(Vector3 destination)
    {
        rb.MovePosition(transform.position + destination * Time.deltaTime * followSpeed);
    }
    void FollowCollector(Vector3 destination)
    {
        rb.MovePosition(transform.position + destination * Time.deltaTime * followSpeed);
        if (destination.magnitude <= destroyRange)
        {
            Destroy(gameObject);
        }
    }
    public enum NeutralCubeState
    {
        Standing,
        Follow_Player,
        Follow_Collector
    }
}
