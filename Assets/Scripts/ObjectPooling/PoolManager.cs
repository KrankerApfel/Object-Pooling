using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
   static private PoolManager _singleton;
   public static PoolManager Instance(){return _singleton;}

   private Dictionary<ObjectType, Pool> poolDict;
   public List<ObjectForPool> data;

   private void Awake()
   {
      _singleton = this;
   }

   public void Initialize()
   {
      poolDict = new Dictionary<ObjectType, Pool>();
      foreach (ObjectForPool obj in data)
      {
         Pool pool = new Pool();
         pool.Initialize(obj.Prefab, obj.Number);
         poolDict.Add(obj.ObjectType, pool);
      }
   }

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
      return poolDict[t].PullObject();
   }
   
   public void ReleasePooledObject(PoolableObject o)
   {
      o.DeInit();
      
   }
}
