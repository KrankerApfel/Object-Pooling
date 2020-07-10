using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//gameobject that has the gamemanager
public class GameManager : MonoBehaviour
{
    private FollowTargetUpdater _followTargetUpdater;
    private TargetEdibleUpdater _targetEdible;
    private PacmanScoreUpdater _pacmanScoreUpdater;
    private GameEndUpdater _gameEndUpdater;

    private void Awake()
    {
        Time.timeScale = 1f;
        
        _followTargetUpdater = new FollowTargetUpdater();
        _followTargetUpdater.InitAccessors();
        
        _targetEdible = new TargetEdibleUpdater();
        _targetEdible.InitAccessors();
        
        
        _pacmanScoreUpdater = new PacmanScoreUpdater();
        _pacmanScoreUpdater.InitAccessors();
        
        _gameEndUpdater = new GameEndUpdater();
        _gameEndUpdater.InitAccessors();
    }

    // Update is called once per frame
    void Update()
    {
       _followTargetUpdater.SystemUpdate();
       _targetEdible.SystemUpdate();
       _pacmanScoreUpdater.SystemUpdate();
       _gameEndUpdater.SystemUpdate();
    }
}
