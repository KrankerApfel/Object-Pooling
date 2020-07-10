using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//easy reference to all pacmans in scene
public class PacmanList : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    private void Awake()
    {
        TAccessor<PacmanList>.Instance.AddItem(this);

    }

    private void OnDestroy()
    {
        TAccessor<PacmanList>.Instance.RemoveItem(this);
    }
}
