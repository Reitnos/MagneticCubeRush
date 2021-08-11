using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVelocityMovementMobile : MonoBehaviour, IPlayerMobileControl
{
    private Rigidbody rb;
    private float moveSpeed = 20f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 directionVector)
    {
        Vector3 velocityVector = directionVector.normalized * moveSpeed;
        transform.forward = directionVector.normalized;
        velocityVector.y = rb.velocity.y;
        rb.velocity = velocityVector;
    }
}
