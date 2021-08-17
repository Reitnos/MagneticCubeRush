using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleInteraction : MonoBehaviour
{
    private Vector3 startPosition, startForward;
    public event Action playerCollidedWithObstacle;
    private void Start()
    {
        startPosition = transform.position;
        startForward = transform.forward;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            SetPositionToStart();
            InvokeCollisionEvent();
        }
    }

    private void InvokeCollisionEvent()
    {
        playerCollidedWithObstacle?.Invoke();
    }

    private void SetPositionToStart()
    {
        transform.position = startPosition;
        transform.forward = startForward;
    }
}
