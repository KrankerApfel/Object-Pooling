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
    private bool _gameEnded;

    private TAccessor<PacmanList> _pacmans;

    private TAccessor<EdibleList> _edibles;
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
        _pacmans = TAccessor<PacmanList>.Instance;
        _edibles = TAccessor<EdibleList>.Instance;
    }

    public void SystemUpdate()
    {
        if (_pacmans.GetAllModules().Count == 0 && !_gameEnded)
        {
            _gameEnded = true;
            Time.timeScale = 0f;
            EndGame.instance.GameEnd(false);
        }
        else if (_edibles.GetAllModules().Count == 0 && !_gameEnded)
        {
            _gameEnded = true;
            Time.timeScale = 0f;
            EndGame.instance.GameEnd(true);
        }

        foreach (var module in _targetEdible.GetAllModules())
        {
            _pacmanTarget = module.GuessTheBestEntityToTarget();
            float distance = module.GetDistanceToClosestGhost();
            if (distance < 7f)
            {
                _fleeTarget = module.GuessBestGhostToFlee();
                Vector3 pacmanPos = module.transform.position;
                Vector3 dirToPlayer = pacmanPos - _fleeTarget.transform.position;
                Vector3 newPos = pacmanPos + dirToPlayer;

                module.navMeshAgent.SetDestination(newPos);
            }
            else if (_pacmanTarget != null)
            {
                module.navMeshAgent.SetDestination(_pacmanTarget.transform.position);
            }
            else
            {
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
