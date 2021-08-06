using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosionEffected : MonoBehaviour, IExplosionMove
{
    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    
    public void AddObjectForce(float force, Vector3 position, float explosionRadius)
    {
        playerRb.AddExplosionForce(force, transform.position, explosionRadius);
    }
}
