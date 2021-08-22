using System;
using System.Xml.Schema;
using UnityEngine;

public class KeyboardInput : PlayerInput
{
   
    
    
    void FixedUpdate()
    {
        ArrowKeyMovementControl();
        
        
    }

    private void Update()
    {
        JumpControl();
    }

    private void ArrowKeyMovementControl()
    {
        Vertical = Input.GetAxis("Vertical");


        Horizontal = Vertical >= 0 ? Input.GetAxis("Horizontal") : - Input.GetAxis("Horizontal");
    }

    private void JumpControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            PlayerController.playerState = PlayerController.PlayerState.jumpPressed;
        }
    }
    
}