using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileTouchControl : MonoBehaviour
{
   
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    public float moveSpeed = 10f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if(theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }
            else if(theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float diffx = touchEndPosition.x - touchStartPosition.x;
                float diffz = touchEndPosition.y - touchStartPosition.y;
                Vector3 direction = new Vector3(diffx, 0, diffz).normalized;
                Vector3 movementVec = direction * moveSpeed;

                transform.forward = direction;
                movementVec.y = rb.velocity.y;
                rb.velocity = movementVec;
            }
        }
      
    }

}
