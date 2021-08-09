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
   
    private GameObject player;
    void FixedUpdate()
    {
        SeeAndFollowPlayer();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    void SeeAndFollowPlayer()
    {
        
        /*
        float distance = (player.transform.position - this.gameObject.transform.position).magnitude; 
        // look if the calculated distance is less then the attack distance, then check for ray.
        if (distance < followPlayerDistance)
        {
            Vector3 direction = player.transform.position - (transform.position + Vector3.up);
            Ray ray = new Ray(transform.position + Vector3.up, direction);
           

            if (Physics.Raycast(ray, out RaycastHit hit, followPlayerDistance))
            {
                

                if (hit.collider.gameObject == player)
                {
                    navAgent.SetDestination(player.transform.position);

                }
            }
        }
        */
        Vector3 destination = (player.transform.position - this.gameObject.transform.position);
        float distance = destination.magnitude;
        if (distance < followPlayerDistance)
        {
            Vector3 direction = player.transform.position - transform.position;
            Ray ray = new Ray(transform.position + Vector3.up, direction);


            if (Physics.Raycast(ray, out RaycastHit hit, followPlayerDistance))
            {
                if (hit.collider.gameObject == player)
                {
                   rb.MovePosition(transform.position + destination * Time.deltaTime * followSpeed);
            
                }
            }
        }


    }
}
