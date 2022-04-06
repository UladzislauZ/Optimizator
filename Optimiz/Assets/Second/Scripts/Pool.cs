using System;
using System.Collections.Generic;
using UnityEngine;


public class Pool : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected int _startCount = 50;
    [SerializeField] protected int _resizeCount = 10;
    
    protected Stack<GameObject> _free = new Stack<GameObject>();
    
    private GameObject[] _asset;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        for (int i = 0; i < _startCount; i++)
        {
            _free.Push(GenerateObject());
        }
    }

    protected GameObject GenerateObject()
    {
        var newObject = Instantiate(prefab, transform);
        newObject.name += "(PoolObject)";
        newObject.SetActive(false);
        return newObject;
    }

    public GameObject GetObject()
    {
        if (_free.Count == 0)
        {
            for (int i = 0; i < _resizeCount; i++)
            {
                _free.Push(GenerateObject());
            }
        }

        return _free.Pop();
    }

    public void Return(GameObject obj)
    {
        _free.Push(obj);
    }
}