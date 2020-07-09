using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    private PoolManager _poolManager;

    private List<PoolableObject> _poolList = new List<PoolableObject>();

    private ObjectType t;
    // Start is called before the first frame update
    void Start()
    {
        _poolManager = PoolManager.Instance();

        for (int i = 0; i < 10; ++i)
        {
            PoolableObject obj = _poolManager.GetPooledObject(ObjectType.ENEMY);
            if (obj != null)
            {
                obj.Init();
                _poolList.Add(obj);
            }
        }

        int objCount = _poolList.Count;
        for (int i = 0; i < objCount; ++i)
        {
            if (_poolList[i] != null)
            {
                _poolManager.ReleasePooledObject(_poolList[i]);
            }
        }

    }
}
