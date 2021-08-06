using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 5f;
    [SerializeField] private float countTime;

    private ObjectPool objectPool;

    [SerializeField] private GameObject prefab;

    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    private void Update()
    {
        countTime += Time.deltaTime;
        if (countTime >= spawnTime)
        {
             GameObject newPooledObject = objectPool.GetObject(prefab);
             newPooledObject.transform.position = this.transform.position;
             countTime = 0f;
        }
    }
}
