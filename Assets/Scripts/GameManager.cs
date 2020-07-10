using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//gameobject that has the gamemanager
public class GameManager : MonoBehaviour
{
    public Updater _updater;
    public FollowTargetUpdater _FollowTargetUpdater;
    public GhostScoreUpdater _GhostScoreUpdater;

    private void Awake()
    {
        Time.timeScale = 1f;
        _updater = Updater.Instance;
        _updater.InitAccessors();
        
        _FollowTargetUpdater = new FollowTargetUpdater();
        _FollowTargetUpdater.InitAccessors();

        
        _GhostScoreUpdater = new GhostScoreUpdater();
        _GhostScoreUpdater.InitAccessors();

    }

    // Update is called once per frame
    void Update()
    {
       _updater.SystemUpdate(); 
       _FollowTargetUpdater.SystemUpdate();
       _GhostScoreUpdater.SystemUpdate();
    }
}
