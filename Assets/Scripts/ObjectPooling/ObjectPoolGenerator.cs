using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ObjectPoolGeneratorData", menuName = "ScriptableObjects/ObjectPoolGeneratorData")]
public class ObjectPoolGenerator : ScriptableObject
{
   public Dictionary<int, PoolableObject> dict;
   
}
