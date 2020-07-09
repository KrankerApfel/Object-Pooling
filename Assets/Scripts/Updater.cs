using System;
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
    private float _timeLeft;
    private PacmanList _target;
    private bool _isSearchingTarget;
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
        
    }

    public void SystemUpdate()
    {
        _timeLeft -= Time.deltaTime;
        if (_target == null || _timeLeft <= 0)
        {
            _isSearchingTarget = true;
            _timeLeft = 1f;
        }
        //make a method in accessor to fill it in
        //modules are monobehaviors that you can fill in data with 
        foreach (var module in _entities.GetAllModules())
        {
            GameObject entity = module.obj.gameObject;
            //GameObject entity = module.Value.Gameobject; 
        }
        
        //function so that all ghosts follow pacman 
        foreach (var module in _followTargets.GetAllModules()){

            if (_isSearchingTarget)
            {
                _isSearchingTarget = false;
                _target = module.GuessTheBestEntityToTarget();
                if (_target == null)
                {
                    Debug.Log("is null");
                }
            }

            module.navMeshAgent.SetDestination(_target.transform.position);


            //setDestination
            //isStopped 
        }
    }
}

/*
Public class MyUpdater : IUpdater
{
    Public void SystemUpdate()
    {
        TAccessor<MyModule> myModuleAccessor = TAccessor<MyModule>.Instance();
        TAccessor<MyOhterModule> myOtherModuleAccessor = TAccessor<MyOhterModule>.Instance();
        Foreach(var module in myModuleAccessor.GetAllModules())
        {
            GameObject myEntity = module.Value.GameObject;
            MyOtherModule otherModule = myModuleAccessor.TryGetModule(myEntity);
            If(otherModule != null)
            DoSomething();
        }
    }
}*/