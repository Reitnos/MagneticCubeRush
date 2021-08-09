using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DestroyCube : MonoBehaviour
{
    // make the collected cubes disappear on the collection zone and count them points to the player.
    private NeutralCubeCollect cubeCollect;

    private void Start()
    {
        cubeCollect = GetComponent<NeutralCubeCollect>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Detector"))
        {
            cubeCollect.CollectedByPlayer(1);
            
            cubeCollect.DestroyCube();
        }
    }
    
    
}
