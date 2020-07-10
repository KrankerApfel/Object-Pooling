﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdater
{
    void SystemUpdate();
    void InitAccessors();
}

[Serializable]
public class Updater : IUpdater
{
    private TAccessor<Entities> _entities;
    private TAccessor<FollowTarget> _followTargets;

    private TAccessor<TargetEdible> _targetEdible;
    //private float _timeLeft;
    private PacmanList _ghostTarget;

    private EdibleList _pacmanTarget;
    // bool _isSearchingTarget;
    #region Singleton

    private static Updater _instance;
        
    public static Updater Instance {
        get {
            if (_instance == null)
            {
                _instance = new Updater();
            }
            else
            {
                Debug.LogWarning("Instance already exists");
            }
            return _instance;
        }
    }


    #endregion

    public void InitAccessors()
    {
        _entities = TAccessor<Entities>.Instance;
        _followTargets = TAccessor<FollowTarget>.Instance;
        _targetEdible = TAccessor<TargetEdible>.Instance;
        
    }

    public void SystemUpdate()
    {
        /*_timeLeft -= Time.deltaTime;
        if (_target == null || _timeLeft <= 0)
        {
            _isSearchingTarget = true;
            _timeLeft = 1f;
        }*/
        foreach (var module in _entities.GetAllModules())
        {
            GameObject entity = module.obj.gameObject;
            //GameObject entity = module.Value.Gameobject; 
        }

        foreach (var module in _targetEdible.GetAllModules())
        {
            _pacmanTarget = module.GuessTheBestEntityToTarget();
            if (_pacmanTarget != null)
            {
                module.navMeshAgent.SetDestination(_pacmanTarget.transform.position);
            }
        }
        
        //function so that all ghosts follow pacman 
        foreach (var module in _followTargets.GetAllModules()){

            //if (_isSearchingTarget)
            //{
                //_isSearchingTarget = false;
            _ghostTarget = module.GuessTheBestEntityToTarget();
            if (_ghostTarget != null)
            {
                module.navMeshAgent.SetDestination(_ghostTarget.transform.position);
            }
                
//            }
        }
    }
}
