using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetEdible : MonoBehaviour
{
    private List<EdibleList> _edibles;
    private List<GhostList> _ghosts;
    public NavMeshAgent navMeshAgent;
    private void Awake()
    {
        TAccessor<TargetEdible>.Instance.AddItem(this);
    }

    private void OnDestroy()
    {
        TAccessor<TargetEdible>.Instance.RemoveItem(this);
    }

    //find distance to the closest ghost to know if pacman has to run
    public float GetDistanceToClosestGhost()
    {

        float bestDistance = float.PositiveInfinity;
        if (_ghosts == null)
            _ghosts = TAccessor<GhostList>.Instance.GetAllModules();
        

        foreach (var ghost in _ghosts)
        {
            float distance = Vector3.Distance(this.gameObject.transform.position, ghost.transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
            }
        }

        return bestDistance;
    }
    
    //If the ghost is close, get that ghost to flee 
    public GhostList GuessBestGhostToFlee()
    {
        GhostList bestTarget = null;
        float bestDistance = float.PositiveInfinity;
        if (_ghosts == null)
        {
            _ghosts = TAccessor<GhostList>.Instance.GetAllModules();
        }

        foreach (var ghost in _ghosts)
        {
            float distance = Vector3.Distance(this.gameObject.transform.position, ghost.transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestTarget = ghost;
            }
        }

        return bestTarget;
    }
    
    //if a ghost isn't close, find the closest edible to eat
    public EdibleList GuessTheBestEntityToTarget()
    {
        EdibleList bestTarget = null;
        float bestDistance = float.PositiveInfinity;
        if (_edibles == null)
        {
            _edibles = TAccessor<EdibleList>.Instance.GetAllModules();
        }
        foreach (var edible in _edibles)
        {
            float distance = Vector3.Distance(this.gameObject.transform.position, edible.transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestTarget = edible;
            }
        }

        return bestTarget;
    }
}
