using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddForceControlMobile : MonoBehaviour, IPlayerMobileControl
{
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Move(Vector3 directionVector)
    {
        transform.forward = directionVector.normalized;
        rb.AddForce(directionVector* (rb.mass /2f)) ;
    }
}
