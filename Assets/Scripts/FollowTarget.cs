using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    private List<PacmanList> _pacmans;
    private void Awake()
    {
        TAccessor<FollowTarget>.Instance.AddItem(this);
    }

    private void OnDestroy()
    {
        TAccessor<FollowTarget>.Instance.RemoveItem(this);
    }

    
    //find closest pacman to chase
    public PacmanList GuessTheBestEntityToTarget()
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
            float distance = Vector3.Distance(this.gameObject.transform.position, pacman.transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestTarget = pacman;
            }

        }

        return bestTarget;
    }

}
