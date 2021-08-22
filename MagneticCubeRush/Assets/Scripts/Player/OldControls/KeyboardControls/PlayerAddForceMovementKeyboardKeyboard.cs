using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddForceMovementKeyboardKeyboard : MonoBehaviour , IPlayerMovementKeyboard
{
    
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Move(float movement, float rotation)
    {
        
        
        Vector3 eulerRotation = new Vector3(0, rotation, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerRotation * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
