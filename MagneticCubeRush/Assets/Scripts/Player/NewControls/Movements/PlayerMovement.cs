using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected Transform playerTransform;
    protected PlayerInput playerInput;


    protected virtual void Awake()
    {
    }

    public void Move()
    {
        if(playerInput)
        {
            Vector3 movementVector =new Vector3(playerInput.Horizontal, 0, playerInput.Vertical); // assigning inputs to the vector3 plane.
            Move(movementVector);
        }
    }


    public virtual void Jump()
    {
        Debug.Log("Player Jumped!");
    }
    protected abstract void Move(Vector3 movementInput);

}

