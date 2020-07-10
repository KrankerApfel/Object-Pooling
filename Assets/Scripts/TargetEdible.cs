using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetEdible : MonoBehaviour
{
    private List<EdibleList> _edibles;
    public NavMeshAgent navMeshAgent;
    private void Awake()
    {
        TAccessor<TargetEdible>.Instance.AddItem(this);
    }

    private void OnDestroy()
    {
        TAccessor<TargetEdible>.Instance.RemoveItem(this);
    }
    
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
            //Debug.Log("position :" + pacman.transform.position);
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
