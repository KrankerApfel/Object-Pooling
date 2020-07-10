using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//gameobject that has the gamemanager
public class GameManager : MonoBehaviour
{
    public Updater _updater;
<<<<<<< HEAD
    private FollowTargetUpdater _followTargetUpdater;
    private TargetEdibleUpdater _targetEdible;
=======
    public FollowTargetUpdater _FollowTargetUpdater;
    public GhostScoreUpdater _GhostScoreUpdater;
    public PacmanScoreUpdater _PacmanScoreUpdater;
>>>>>>> 0076f623c9cb4b9f8ba6c9b885bd475244559ba5

    private void Awake()
    {
        Time.timeScale = 1f;
        _updater = Updater.Instance;
        _updater.InitAccessors();
        
<<<<<<< HEAD
        _followTargetUpdater = new FollowTargetUpdater();
        _followTargetUpdater.InitAccessors();
        
        _targetEdible = new TargetEdibleUpdater();
        _targetEdible.InitAccessors();
=======
        _FollowTargetUpdater = new FollowTargetUpdater();
        _FollowTargetUpdater.InitAccessors();
        
        _GhostScoreUpdater = new GhostScoreUpdater();
        _GhostScoreUpdater.InitAccessors();
        
        _PacmanScoreUpdater = new PacmanScoreUpdater();
        _PacmanScoreUpdater.InitAccessors();
>>>>>>> 0076f623c9cb4b9f8ba6c9b885bd475244559ba5

    }

    // Update is called once per frame
    void Update()
    {
       _updater.SystemUpdate(); 
<<<<<<< HEAD
       _followTargetUpdater.SystemUpdate();
       _targetEdible.SystemUpdate();
=======
       _FollowTargetUpdater.SystemUpdate();
       _GhostScoreUpdater.SystemUpdate();
       _PacmanScoreUpdater.SystemUpdate();
>>>>>>> 0076f623c9cb4b9f8ba6c9b885bd475244559ba5
    }
}
