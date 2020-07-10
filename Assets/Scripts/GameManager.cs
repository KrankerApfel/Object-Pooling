using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//gameobject that has the gamemanager
public class GameManager : MonoBehaviour
{
    public Updater _updater;
    private FollowTargetUpdater _followTargetUpdater;
    private TargetEdibleUpdater _targetEdible;

    private void Awake()
    {
        Time.timeScale = 1f;
        _updater = Updater.Instance;
        _updater.InitAccessors();
        
        _followTargetUpdater = new FollowTargetUpdater();
        _followTargetUpdater.InitAccessors();
        
        _targetEdible = new TargetEdibleUpdater();
        _targetEdible.InitAccessors();

    }

    // Update is called once per frame
    void Update()
    {
       _updater.SystemUpdate(); 
       _followTargetUpdater.SystemUpdate();
       _targetEdible.SystemUpdate();
    }
}
