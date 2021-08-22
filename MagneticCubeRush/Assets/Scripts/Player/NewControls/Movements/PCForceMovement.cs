using UnityEngine;

public class PCForceMovement : PlayerMovement
{
    [Header("Speed arrangement")]
    public float moveSpeed = 200.0f;
    public float rotationSpeed = 100.0f;


    protected override void Awake()
    {
        base.Awake();
        playerInput = gameObject.AddComponent<KeyboardInput>();
    }

    protected override void Move(Vector3 movementInput)
    {

        //TODO implement!!
        // transform.forward = movementInput.normalized;
        movementInput.z *= moveSpeed;
        movementInput.x *= rotationSpeed;


        
        rb.AddForce(movementInput.z * transform.forward *  (rb.mass / 2f));
        
        Vector3 eulerRotation = new Vector3(0, movementInput.x, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerRotation * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

    }

    public override void Jump()
    {
        Debug.Log("Player jumped with PC Force Movement script");
    }
}
