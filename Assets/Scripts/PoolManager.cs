using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
   private static PoolManager _singleton;
   public static PoolManager Instance(){return _singleton;}

   private Dictionary<ObjectType, Pool> poolDict;
   public List<ObjectForPool> data;

   private void Awake(){_singleton = this;}

   private void Start()
   {
      foreach (ObjectForPool d in data)
      {
         Pool p = new Pool();
         p.Initialize(d.Prefab, d.Number);
         poolDict.Add(d.ObjectType, p );
      }
   }

   public PoolableObject GetPooledObject(ObjectType t)
   {
      return poolDict[t].getObject();
   }
   
   public void ReleasePooledObject(PoolableObject o)
   {
      ObjectForPool d = data.First(x => x.Prefab == o);
      poolDict[d.ObjectType].pool.Add(o);
   }
}
