using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int listSize;
    private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();
    

    private void Update()
    {
        listSize = objectPool.Count;
    }

    
    // Get an Object from the pool.
    public GameObject GetObject(GameObject gameObject)
    {
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            if (objectList.Count == 0) 
            {
                // if the desired prefab currently doesn't have any pool.
                // Instantiate a new one and give it.
                return CreateNewObject(gameObject);
            }
            else
            {
                // if there is a pool for the desired prefab, take one from the queue and give it.
                GameObject poolObject = objectList.Dequeue();
                poolObject.SetActive(true);
                return poolObject;
            }
        }
        else
            return CreateNewObject(gameObject);

    }

    private GameObject CreateNewObject(GameObject gameObject)
    {
       
        GameObject newObject = Instantiate(gameObject);
        newObject.name = gameObject.name;
        return newObject;
    }

    public void ReturnGameObject(GameObject gameObject)
    {
        // if there is a queue ready for the given prefab, add the prefab to its queue.
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(gameObject);
        }
        // if there is no queue ready for the given prefab, create a new key,value(queue) pair for it.
        else
        {
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(gameObject);
            objectPool.Add(gameObject.name, newObjectQueue);
        }

        gameObject.SetActive(false);

    }
}
