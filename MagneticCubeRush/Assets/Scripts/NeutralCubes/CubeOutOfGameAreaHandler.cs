using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOutOfGameAreaHandler : MonoBehaviour
{
    private NeutralCubeCollect _cubeCollect;
    private void Start()
    {
        _cubeCollect = GetComponent<NeutralCubeCollect>();
    }

    private void Update()
    {
        CheckCubePositionAndIncreaseScore();
    }

    private void CheckCubePositionAndIncreaseScore()
    {
        Vector3 pos = gameObject.transform.position;
        if (pos.x < -12 || pos.x > 12 || pos.z < -19 || pos.z > 21)
        {
            _cubeCollect.CollectedByPlayer(1);
            _cubeCollect.DestroyCube();
        }
    }
}
