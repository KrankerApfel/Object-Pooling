using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//interface for updater
public interface IUpdater
{
    void SystemUpdate();
    void InitAccessors();
}
//updater which handles every update of every mondule
[Serializable]
public class Updater : IUpdater
{
    public float ghostSpeed = 1.0f;
    public float pacSpeed = 6.0f;
    private TAccessor<GhostList> _ghosts; 

    private TAccessor<FollowTarget> _followTargets;

    private TAccessor<TargetEdible> _targetEdible;

    private TAccessor<GhostScore> _ghostScore;
    private PacmanList _ghostTarget;
    private bool _isEndGame;
    private EdibleList _pacmanTarget;

    private GhostList _fleeTarget;
    private bool _gameEnded;

    private TAccessor<PacmanList> _pacmans;

    private TAccessor<EdibleList> _edibles;
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

    //get all instances at init to have all references
    public void InitAccessors()
    {
        _followTargets = TAccessor<FollowTarget>.Instance;
        _targetEdible = TAccessor<TargetEdible>.Instance;
        _ghostScore = TAccessor<GhostScore>.Instance;
        _pacmans = TAccessor<PacmanList>.Instance;
        _ghosts = TAccessor<GhostList>.Instance;
        _edibles = TAccessor<EdibleList>.Instance;
        _gameEnded = false;
    }

    public void SystemUpdate()
    {
        //checks if game is finisehd 
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


        
     
    }
}
