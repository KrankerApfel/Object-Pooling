using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public List<PoolableObject> pool;

    // ajoute n fois l'objet passé en parramètre dans la pool.
    public void Initialize(PoolableObject obj, int n)
    {
        pool = Enumerable.Repeat(obj, n).ToList();
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
