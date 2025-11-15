using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize;
    
    private List<GameObject> objectPool = new List<GameObject>();

    private void Start()
    {
        
        for (int i = 0; i < poolSize; i++)
        {
            objectPool.Add(Instantiate(prefab));
        }
    }


    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        foreach (var obj in objectPool)
        {
            if (!obj.activeSelf)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
    
    
}
