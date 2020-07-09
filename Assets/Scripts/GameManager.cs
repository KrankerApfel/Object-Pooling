using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Updater updater;


    private void Awake()
    {
        updater = Updater.Instance;
        updater.InitAccessors();
    }

    // Update is called once per frame
    void Update()
    {
       updater.SystemUpdate(); 
    }
}
