using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetEdible : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    private void Awake()
    {
        TAccessor<TargetEdible>.Instance.AddItem(this);
    }

    private void OnDestroy()
    {
        TAccessor<TargetEdible>.Instance.RemoveItem(this);
    }

}
