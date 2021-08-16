using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCubeCountInScene : MonoBehaviour
{
    private SceneCubeCount cubeCountScript;

    private void Awake()
    {
        cubeCountScript = FindObjectOfType<SceneCubeCount>();
        cubeCountScript.CountIncrease();
    }
}
