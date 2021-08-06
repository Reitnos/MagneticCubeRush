using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    private void Start()
    {
        ExplosionState.HasExploded += DestroyBomb;
    }

    private void DestroyBomb()
    {
        Destroy(this.gameObject);
    }
}
