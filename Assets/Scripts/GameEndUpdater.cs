using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndUpdater : IUpdater
{
    private bool _gameEnded;
    private TAccessor<PacmanList> _pacmans;
    private TAccessor<EdibleList> _edibles;


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

    public void InitAccessors()
    {
        _pacmans = TAccessor<PacmanList>.Instance;
        _edibles = TAccessor<EdibleList>.Instance;
        _gameEnded = false;
    }
}
