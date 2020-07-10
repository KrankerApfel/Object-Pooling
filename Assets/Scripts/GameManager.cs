using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Updater _updater;


    private void Awake()
    {
        _updater = Updater.Instance;
        _updater.InitAccessors();
    }

    // Update is called once per frame
    void Update()
    {
       _updater.SystemUpdate(); 
    }
}
