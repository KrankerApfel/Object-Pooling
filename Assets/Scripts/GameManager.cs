using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//gameobject that has the gamemanager
public class GameManager : MonoBehaviour
{
    private Updater _updater;
    private float ghostSpeed = 1.0f;
    private float pacSpeed = 6.0f;
    private TAccessor<GhostList> _ghosts; 
    private TAccessor<PacmanList> _pacs; 
    public float GhostSpeed
    {
        get => ghostSpeed;
        set
        { 
            ghostSpeed = value;
            foreach (var module in _ghosts.GetAllModules())
            {
                module.navMeshAgent.speed = ghostSpeed;
            }
        }
    }
    public float PacSpeed
    {
        get => pacSpeed;
        set
        { 
            pacSpeed = value;
            foreach (var module in _pacs.GetAllModules())
            {
                module.navMeshAgent.speed = pacSpeed;
            }
        }
    }

    private void Awake()
    {
        Time.timeScale = 1f;
        _updater = Updater.Instance;
        _updater.InitAccessors();
        _ghosts = TAccessor<GhostList>.Instance;
    }

    // Update is called once per frame
    void Update()
    {
       _updater.SystemUpdate(); 
    }
}
