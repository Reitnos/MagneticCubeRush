using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosionEffected : MonoBehaviour, IExplosionMove
{
    private Rigidbody playerRb;
    private INPCState _bombState;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    
    // method to apply explosion force to the player.
    public void AddObjectForce(float force, Vector3 position, float explosionRadius)
    {
        playerRb.AddExplosionForce(force, position, explosionRadius);
    }
    
}
