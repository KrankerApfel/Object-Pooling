using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScoreUpdater : IUpdater
{
    public float ghostSpeed = 1.0f;
    private TAccessor<GhostList> _ghosts; 


    public void SystemUpdate()
    {
        foreach (var module in _ghosts.GetAllModules())
        {
            module.navMeshAgent.speed = ghostSpeed;
        }
    }

    public void InitAccessors()
    {
        _ghosts = TAccessor<GhostList>.Instance;

    }
}
