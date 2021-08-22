using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    private Rigidbody rb;
    public static PlayerState playerState;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerState = PlayerState.onGround;

    }

    private void Update()
    {
        if (playerState == PlayerState.onGround)
        {
            playerMovement.Move();
            
        }

        if (playerState == PlayerState.jumpPressed)
        {
            playerMovement.Jump();
            playerState = PlayerState.onGround;
        }
            

    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Ground"))
    //     {
    //         playerState = PlayerState.onGround;
    //     }
    // }

    public enum PlayerState
    {
        onGround,
        jumpPressed
    }

}