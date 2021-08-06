using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    [Header("Explosion Particle:")]
    [SerializeField] private GameObject explosionEffect;
    
    [Header("Explosion Parameters:")]
    public float explosionRadius = 5f;
    public float force = 700f;

    private IExplosionMove _explosionEffectedObject;
   
    private ExplosionState _explosionState;
    private void Start()
    {
        _explosionState = gameObject.GetComponent<NPCBomb_StateManager>().explosionState;
        _explosionState.HasExploded += DestroyBomb;
    }

    private void DestroyBomb()
    {
        PlayExplosionEffect();
        
        Collider[] effectedColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        AddExplosionForce(effectedColliders);
        gameObject.SetActive(false);
    }

    private void AddExplosionForce(Collider[] effectedColliders)
    {
        foreach (Collider effectedObject in effectedColliders)
        {
            _explosionEffectedObject = effectedObject.GetComponent<IExplosionMove>();
            if (_explosionEffectedObject != null)
            {
                //TODO this script should care about player's rigidbody
                //player.AddForce(force,transform.position, explosionRadius);
                
                _explosionEffectedObject.AddObjectForce(force,transform.position,explosionRadius);
            }
            
        }
    }

    private void PlayExplosionEffect()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}