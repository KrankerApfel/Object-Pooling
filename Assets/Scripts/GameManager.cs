﻿using System;
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
    public PacmanScoreUpdater _pacmanScoreUpdater;

    private void Awake()
    {
        Time.timeScale = 1f;
        _updater = Updater.Instance;
        _updater.InitAccessors();
        
        _followTargetUpdater = new FollowTargetUpdater();
        _followTargetUpdater.InitAccessors();
        
        _targetEdible = new TargetEdibleUpdater();
        _targetEdible.InitAccessors();
        
        
        _pacmanScoreUpdater = new PacmanScoreUpdater();
        _pacmanScoreUpdater.InitAccessors();
    }

    // Update is called once per frame
    void Update()
    {
       _updater.SystemUpdate(); 
       _followTargetUpdater.SystemUpdate();
       _targetEdible.SystemUpdate();
       _pacmanScoreUpdater.SystemUpdate();
    }
}
