using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class ObjectToPool : MonoBehaviour
{
    public static ObjectToPool Instance {  get; private set; }

    private List<GameObject> objects;

    [SerializeField] private GameObject prefab;
    [SerializeField] private int amountToPool;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameObject tmp;
        objects = new List<GameObject>();
        
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(prefab);
            tmp.SetActive(false);
            objects.Add(tmp);
        }
    }

    public GameObject PooledObject()
    {
        for(int i =  0; i < amountToPool; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }
        }
        return null;
    }
}
