using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;





// spawner class is attached to a empty GameObject called spawner.
// basically it periodically spawns new npc bombs from the object pool of the game.
public class Spawner : MonoBehaviour
{
    
    [SerializeField] private float spawnTime = 5f;
    [SerializeField] private float countTime;
    [SerializeField] private float spawnRadius = 20f;

    private ObjectPool _objectPool;
    private Vector3 _spawnPosition;

    [SerializeField] private GameObject prefab;

    private void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    private void Update()
    {
        if(CheckTimeToSpawn())
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        GameObject newPooledObject = _objectPool.GetObject(prefab);
        Vector3 _randomPosition = UnityEngine.Random.insideUnitSphere * spawnRadius;
        _spawnPosition = transform.position + _randomPosition;
        if (NavMesh.SamplePosition(_spawnPosition, out NavMeshHit hit, 5f, NavMesh.AllAreas))
        {
            _spawnPosition = hit.position;
        }

        newPooledObject.transform.position = _spawnPosition;
    }

    private bool CheckTimeToSpawn()
    {
        countTime += Time.deltaTime;
        if (countTime >= spawnTime)
        {
            countTime = 0f;
            return true;
        }

        return false;
    }
}
