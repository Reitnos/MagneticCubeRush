using UnityEngine;

public class PCVelocityMovement : PlayerMovement
{
    [Header("Speed arrangement")]
    public float moveSpeed = 20.0f;
    public float rotationSpeed = 100.0f;

    protected override void Awake()
    {
        base.Awake();
        playerInput = gameObject.AddComponent<KeyboardInput>();
    }


    protected override void Move(Vector3 movementInput)
    {
        
        
        movementInput.z *= moveSpeed;
        movementInput.x *= rotationSpeed;

        // moving and rotating the player according to the given speed parameters.
        // using rigidbody so that unwanted behaviours like passing inside a wall wont happen.
        Vector3 movementVec = transform.forward * movementInput.z;
        movementVec.y = rb.velocity.y;
        rb.velocity = movementVec;

        
        Vector3 eulerRotation = new Vector3(0, movementInput.x, 0);
        
        
        Quaternion deltaRotation = Quaternion.Euler(eulerRotation * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
    
    public override void Jump()
    {
        Debug.Log("Player jumped with PC Velocity Movement script");
    }
}
