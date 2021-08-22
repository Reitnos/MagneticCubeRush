using UnityEngine;

public class MobileVelocityMovement : PlayerMovement
{
    public float moveSpeed = 0.05f;

    protected override void Awake()
    {
        base.Awake();
        playerInput = gameObject.AddComponent<MobileInput>();
    }

    protected override void Move(Vector3 movementInput)
    {
        // Vector3 velocityVector = directionVector.normalized * moveSpeed;
        Vector3 velocityVector = movementInput.magnitude * movementInput.normalized * moveSpeed;
       
        if(movementInput.normalized != Vector3.zero) playerTransform.forward = movementInput.normalized;
        velocityVector.y = rb.velocity.y;
        rb.velocity = velocityVector;
    }
    public override void Jump()
    {
        Debug.Log("Player jumped with Mobile Velocity Movement script");
    }
}
