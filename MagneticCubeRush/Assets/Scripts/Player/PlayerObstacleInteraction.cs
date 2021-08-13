using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleInteraction : MonoBehaviour
{
    private Vector3 startPosition, startForward;
    private void Start()
    {
        startPosition = transform.position;
        startForward = transform.forward;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            transform.position = startPosition;
            transform.forward = startForward;
        }
    }
}
