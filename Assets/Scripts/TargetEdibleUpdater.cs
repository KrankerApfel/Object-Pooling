using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetEdibleUpdater : IUpdater
{
    private TAccessor<TargetEdible> _edibles;
    private List<EdibleList> _ediblesList;
    private List<GhostList> _ghosts;
    public NavMeshAgent navMeshAgent;


    public void SystemUpdate()
    {
        //pacmans behavior
        foreach (var module in _edibles.GetAllModules())
        {
            EdibleList pacmanTarget = GuessTheBestEntityToTarget(module.gameObject);
            float distance = GetDistanceToClosestGhost(module.gameObject);
            
            //if a ghost is nearby, try to flee
            if (distance < 6f)
            {
                GhostList fleeTarget = GuessBestGhostToFlee(module.gameObject);
                Vector3 pacmanPos = module.transform.position;
                Vector3 dirToPlayer = pacmanPos - fleeTarget.transform.position;
                Vector3 newPos = pacmanPos + dirToPlayer;

                module.navMeshAgent.SetDestination(newPos);
            }
            //if no ghosts are nearby, eat edibles
            else if (pacmanTarget != null)
            {
                module.navMeshAgent.SetDestination(pacmanTarget.transform.position);
            }
        }

    }

    public void InitAccessors()
    {
        _edibles = TAccessor<TargetEdible>.Instance;
    }
    
    
    //find distance to the closest ghost to know if pacman has to run
    public float GetDistanceToClosestGhost(GameObject pacman)
    {

        float bestDistance = float.PositiveInfinity;
        if (_ghosts == null)
            _ghosts = TAccessor<GhostList>.Instance.GetAllModules();
        

        foreach (var ghost in _ghosts)
        {
            float distance = Vector3.Distance(pacman.transform.position, ghost.transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
            }
        }

        return bestDistance;
    }
    
    //If the ghost is close, get that ghost to flee 
    public GhostList GuessBestGhostToFlee(GameObject pacman)
    {
        GhostList bestTarget = null;
        float bestDistance = float.PositiveInfinity;
        if (_ghosts == null)
        {
            _ghosts = TAccessor<GhostList>.Instance.GetAllModules();
        }

        foreach (var ghost in _ghosts)
        {
            float distance = Vector3.Distance(pacman.transform.position, ghost.transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestTarget = ghost;
            }
        }

        return bestTarget;
    }
    
    //if a ghost isn't close, find the closest edible to eat
    public EdibleList GuessTheBestEntityToTarget(GameObject pacman)
    {
        EdibleList bestTarget = null;
        float bestDistance = float.PositiveInfinity;
        if (_ediblesList == null)
        {
            _ediblesList = TAccessor<EdibleList>.Instance.GetAllModules();
        }
        foreach (var edible in _ediblesList)
        {
            float distance = Vector3.Distance(pacman.transform.position, edible.transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestTarget = edible;
            }
        }

        return bestTarget;
    }
}
