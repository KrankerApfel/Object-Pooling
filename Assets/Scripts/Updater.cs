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

    private TAccessor<TargetEdible> _targetEdible;

    private TAccessor<GhostScore> _ghostScore;
    //private float _timeLeft;
    private PacmanList _ghostTarget;
    private bool _isEndGame;
    private EdibleList _pacmanTarget;

    private GhostList _fleeTarget;
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
        _ghostScore = TAccessor<GhostScore>.Instance;
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
            float distance = module.GetDistanceToClosestGhost();
            Debug.Log("distance is : " + distance);
            if (distance < 5f)
            {
                _fleeTarget = module.GuessBestGhostToFlee();
                Vector3 dirToPlayer = module.transform.position - _fleeTarget.transform.position;
                Vector3 newPos = _fleeTarget.transform.position + dirToPlayer;
                Debug.Log("pos is :"+newPos);
                module.navMeshAgent.SetDestination(newPos);
            }
            else if (_pacmanTarget != null)
            {
                module.navMeshAgent.SetDestination(_pacmanTarget.transform.position);
            }
            else
            {
                Debug.Log("hi");
                Time.timeScale = 0f;
                EndGame.instance.GameEnd(true);
            }
        }
        
        //function so that all ghosts follow pacman 
        foreach (var module in _followTargets.GetAllModules()){
            _ghostTarget = module.GuessTheBestEntityToTarget();
            if (_ghostTarget != null)
            {
                module.navMeshAgent.SetDestination(_ghostTarget.transform.position);
            }
            else
            {
                    Time.timeScale = 0f;
                    EndGame.instance.GameEnd(false);
            }
                
        }


    }
}
