using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//accessor which can be a list of any type and stores all the components of that type
public class TAccessor<T>
{
    private static TAccessor<T> _instance;
        
    public static TAccessor<T> Instance {
        get {
            if (_instance == null)
            {
                _instance = new TAccessor<T>();
              //  Debug.Log("created accesor of type : " + typeof(T));
            }

            return _instance;
        }
    }

    private List<T> list = new List<T>();

    //get list
    public List<T>GetAllModules()
    {
        return list;
    }
    
    //add an item to the list
    public void AddItem(T item)
    {
        list.Add(item);
    }

    //remove an item to the list
    public void RemoveItem(T item)
    {
        list.Remove(item);
    }

    public bool CheckContainItem(T searchedItem)
    {
        return list.Contains(searchedItem);
    }
    
    public T GetModuleByRef(T reference)
    {
        return list.Find(x => x.Equals(reference));
    }


    
}
