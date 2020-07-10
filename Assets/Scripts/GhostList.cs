using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//list of all ghosts to have an easy reference to all of them
public class GhostList : MonoBehaviour
{
    private void Awake()
    {
        TAccessor<GhostList>.Instance.AddItem(this);
    }

    private void OnDestroy()
    {
        TAccessor<GhostList>.Instance.RemoveItem(this);
    }
}
