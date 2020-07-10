using System;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetUpdater : IUpdater
{
    private TAccessor<FollowTarget> _followTargets;
    private TAccessor<GhostList> _ghosts; 
    private List<PacmanList> _pacmans;


    public void SystemUpdate()
    {
        //chase closest ghost
        foreach (var module in _followTargets.GetAllModules())
        {
            PacmanList _ghostTarget = GuessTheBestEntityToTarget(module.gameObject);
            if (_ghostTarget != null)
            {
                module.navMeshAgent.SetDestination(_ghostTarget.transform.position);
            }
        }
    }

    public void InitAccessors()
    {
        _followTargets = TAccessor<FollowTarget>.Instance;
        _ghosts = TAccessor<GhostList>.Instance;
    }
    
    
    //find closest pacman to chase
    public PacmanList GuessTheBestEntityToTarget(GameObject ghost)
    {
        PacmanList bestTarget = null;
        float bestDistance = float.PositiveInfinity;
        if (_pacmans == null)
        {
            _pacmans = TAccessor<PacmanList>.Instance.GetAllModules();
        }
        foreach (var pacman in _pacmans)
        {
            //Debug.Log("position :" + pacman.transform.position);
            float distance = Vector3.Distance(ghost.transform.position, pacman.transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestTarget = pacman;
            }

        }

        return bestTarget;
    }
}
