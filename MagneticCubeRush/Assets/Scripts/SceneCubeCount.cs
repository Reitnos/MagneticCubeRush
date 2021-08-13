using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCubeCount : MonoBehaviour
{
    private int sceneCubeCount = 0;

    public void CountIncrease()
    {
        sceneCubeCount++;
    }

    public int GetCount()
    {
        return sceneCubeCount;
    }
}
