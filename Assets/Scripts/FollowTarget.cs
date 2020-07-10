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

    

}
