using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : INPCState
{
    public INPCState ChangeState(NPCBomb_StateManager npc)
    {
        if (npc.navAgent == null)
        {
            npc.navAgent = npc.GetComponent<NavMeshAgent>();
            npc.nextLocation = npc.transform.position;

        }

        DoWander(npc);

        if (CanSeePlayer(npc))
        {
            return npc.attackState;
        }
        else
        {
            return npc.wanderState;
        }
            
    }
    void DoWander(NPCBomb_StateManager npc)
    {
        //if close to the target wander distance, choose a new one by random.
        if (npc.navAgent.remainingDistance < 1f)
        {
            Vector3 random = Random.insideUnitSphere * npc.wanderDistance;
            random.y = 0f;
            npc.nextLocation = npc.navAgent.transform.position + random;
            npc.navAgent.SetDestination(npc.nextLocation);
            // check if the found random position is in the nav mesh, if not, find the closest point on the mesh.
            if (NavMesh.SamplePosition(npc.nextLocation, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            {
                npc.nextLocation = hit.position;
                npc.navAgent.SetDestination(npc.nextLocation);
            }
            
        }
    }
    bool CanSeePlayer(NPCBomb_StateManager npc)
    {
        Transform playerTransform = npc.player.transform;
    
        float distance = (playerTransform.transform.position - npc.transform.position).magnitude; 
        // look if the calculated distance is less then the attack distance, then check for ray.
        if (distance < npc.attackDistance)
        {
            Vector3 direction = playerTransform.transform.position - (npc.transform.position + Vector3.up);
            Ray ray = new Ray(npc.transform.position + Vector3.up, direction);
            // Debug.DrawRay(npc.transform.position + Vector3.up, direction, Color.blue);

            if (Physics.Raycast(ray, out RaycastHit hit, npc.attackDistance))
            {
                // Debug.Log("I hit" + hit.collider.name);

                if (hit.collider.gameObject == npc.player)
                {
                    npc.attackTarget = npc.player; 
                    return true;
                }
            }
        }
    

        return false;
    }
}

