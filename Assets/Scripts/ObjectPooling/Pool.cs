using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public List<PoolableObject> pool;

    // ajoute n fois l'objet passé en parramètre dans la pool.
    public void Initialize(PoolableObject obj, int n)
    {
        pool = new List<PoolableObject>();
        for (int i = 0; i < n; i++)
        {
            PoolableObject go = MonoBehaviour.Instantiate(obj);
            go.DeInit();
            pool.Add(go);
        }
        pool = Enumerable.Repeat(obj, n).ToList();
    }


    public PoolableObject PullObject()
    {
        int numberObjectInPool = pool.Count;
        for (int i = 0; i < numberObjectInPool; i++)
        {
            if (!pool[i].IsActive())
            {
                return pool[i];
            }
        }
        return null;
    }
    // prend le premier objet de la pool en la retirant
    public PoolableObject getObject()
    {
        PoolableObject o = pool[0];
        pool.RemoveAt(0);
        o.Init();
        return o;
    }
}
