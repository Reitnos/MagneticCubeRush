using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleWander : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Vector3 nextLocation;
    [SerializeField]
    private float wanderDistance = 15f;
    [SerializeField]
    

   
    void Start()
    {
        nextLocation = this.transform.position;
        navAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        DoWander();
    }

    private void DoWander()
    {
        //if close choose next location
        if (navAgent.remainingDistance < 1f)
        {
            Vector3 random = Random.insideUnitSphere * wanderDistance;
            random.y = 0f;
            nextLocation = this.transform.position + random;

            if (NavMesh.SamplePosition(nextLocation, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            {
                nextLocation = hit.position;
                navAgent.SetDestination(nextLocation);
            }
        }
    }
}
