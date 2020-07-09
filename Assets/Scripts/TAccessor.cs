using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAccessor<T>
{
    private static TAccessor<T> _instance;
        
    public static TAccessor<T> Instance {
        get {
            if (_instance == null)
            {
                _instance = new TAccessor<T>();
                Debug.Log("created accesor of type : " + typeof(T));
            }
            else
            {
                Debug.Log("Instance already exists");
            }
            return _instance;
        }
    }

    public List<T> list = new List<T>();

    public List<T>GetAllModules()
    {
        return list;
    }
    
    //todo method to fill in the list
    
    public void AddItem(T item)
    {
        list.Add(item);
    }

    public void RemoveItem(T item)
    {
        list.Remove(item);
    }
    
    
}
