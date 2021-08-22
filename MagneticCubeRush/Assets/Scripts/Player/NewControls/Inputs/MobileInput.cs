using System;
using UnityEngine;

public class MobileInput : PlayerInput
{
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;

    private bool firstTouch = false;
    private float maxDeltaTime = 0.3f;
    private float maxDeltaPostition = 1f;
    private Vector3 startTouchPosition;
    private float currentDeltaTime = 0f;

    void FixedUpdate()
    {
        MobileMoveControl();
    }

    private void Update()
    {
        JumpControl();
    }
    private void JumpControl()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (firstTouch == false)
            {
                firstTouch = true;
                startTouchPosition = theTouch.position;
            }
            else
            {
                if (currentDeltaTime <= maxDeltaTime && Input.GetTouch(0).phase == TouchPhase.Began && Vector3.Distance(theTouch.position,startTouchPosition) < maxDeltaPostition)
                {
                    PlayerController.playerState = PlayerController.PlayerState.jumpPressed;
                    firstTouch = false;
                }

                    startTouchPosition = theTouch.position;
                    currentDeltaTime = 0f;
               
            }
           

            
        }

        if (firstTouch == true)
        {
            
            currentDeltaTime += Time.deltaTime;
        }
    }
    private void MobileMoveControl()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }
            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                //float diffx = touchEndPosition.x - touchStartPosition.x;
                //float diffz = touchEndPosition.y - touchStartPosition.y;
                //Vector3 direction = new Vector3(diffx, 0, diffz);

                Horizontal = touchEndPosition.x - touchStartPosition.x;
                Vertical = touchEndPosition.y - touchStartPosition.y;
            }
        }
    }
}
