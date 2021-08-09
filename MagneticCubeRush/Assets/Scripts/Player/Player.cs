using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayerMovement
{   
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Move(float movement, float rotation)
    {
        // moving and rotating the player according to the given speed parameters.
        // using rigidbody so that unwanted behaviours like passing inside a wall wont happen.
        Vector3 movementVec = transform.forward * movement;
        movementVec.y = rb.velocity.y;
        rb.velocity = movementVec;

        Vector3 eulerRotation = new Vector3(0, rotation, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerRotation * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
