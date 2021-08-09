using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyControl : MonoBehaviour
{
    // this script allows player to control the collector by arrow keys
    // rotating with left and right, moving with up and down keys.
    
    [Header("Speed arrangement")]
    public float moveSpeed = 20.0f;
    public float rotationSpeed = 200.0f;
    
    private bool goingForward = true;
   
    private IPlayerMovement player;


    private void Awake()
    {
        player = GetComponent<IPlayerMovement>();
    }

    void FixedUpdate()
    {
        ArrowKeyMovementControl();
    }

    private void ArrowKeyMovementControl()
    {
        float movement = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed ;
       
        // check if player is trying to go back or forward, so that while going back, rotation is arranged accordingly.
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            goingForward = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            goingForward = false;
        }

        if (!goingForward)
        {
            rotation = -rotation;
        }

       player.Move(movement, rotation);
    }


}


