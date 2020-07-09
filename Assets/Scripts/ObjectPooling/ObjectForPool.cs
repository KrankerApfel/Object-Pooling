using System;

[Serializable]
public struct ObjectForPool
{
   public ObjectType ObjectType;
   public PoolableObject Prefab;
   public int Number;
}
