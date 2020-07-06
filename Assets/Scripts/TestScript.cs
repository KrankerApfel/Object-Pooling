using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    private PoolManager _poolManager;

    private List<ObjectForPool> _poolList;

    private ObjectType t;
    // Start is called before the first frame update
    void Start()
    {
        _poolManager = PoolManager.Instance();
        _poolList = _poolManager.data;
        foreach (var pool in _poolList)
        {
            PoolableObject poolableObject = _poolManager.GetPooledObject(pool.ObjectType);
            _poolManager.ReleasePooledObject(poolableObject);
        }
    }
}
