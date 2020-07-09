using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Entity{

}
public enum EntityType
{
    Pacman,
    Ghost
}
public class Entities : MonoBehaviour
{
    public GameObject obj;
    public Dictionary<EntityType, Entities> entityDict;
    public EntityType entityType;
    //todo 
    public bool IsActive()
    {
        return gameObject.activeInHierarchy;
    }
    public void Init()
    {
        gameObject.SetActive(true);
    }
    public void DeInit()
    {
        gameObject.SetActive(false);
    }

    public void Initialize(Entities prefab, int nb)
    {
        entityDict = new Dictionary<EntityType, Entities>();
        for (int i = 0; i < nb; ++i)
        {
            Entities entity = MonoBehaviour.Instantiate(prefab);
            entity.DeInit();
            entityDict.Add(prefab.entityType, prefab);
        }
    }

    public Entities GetEntity()
    {
        int nbEntity = entityDict.Count;
        foreach (KeyValuePair<EntityType, Entities> entity in entityDict)
        {
            if (!entity.Value.IsActive())
            {
                return entity.Value;
            }
        }
        return null;
    }
}
