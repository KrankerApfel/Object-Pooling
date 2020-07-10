using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//gameobject that has the gamemanager
public class GameManager : MonoBehaviour
{
    public Updater _updater;
  

    private void Awake()
    {
        Time.timeScale = 1f;
        _updater = Updater.Instance;
        _updater.InitAccessors();
    }

    // Update is called once per frame
    void Update()
    {
       _updater.SystemUpdate(); 
    }
}
