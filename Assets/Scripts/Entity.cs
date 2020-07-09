using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public GameObject obj;
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
}
