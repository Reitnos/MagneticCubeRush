using UnityEngine;

public class MobileForceMovement : PlayerMovement
{
    protected override void Awake()
    {
        base.Awake();
        playerInput = gameObject.AddComponent<MobileInput>();
    }

    protected override void Move(Vector3 movementInput)
    {
        playerTransform.forward = movementInput.normalized;
        rb.AddForce(movementInput * (rb.mass / 2f));
    }
    public override void Jump()
    {
        Debug.Log("Player jumped with Mobile Force Movement script");
    }
}
