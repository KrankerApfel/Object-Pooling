using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//easy reference to all pacmans in scene
public class PacmanList : MonoBehaviour
{
    private void Awake()
    {
        TAccessor<PacmanList>.Instance.AddItem(this);

    }

    private void OnDestroy()
    {
        TAccessor<PacmanList>.Instance.RemoveItem(this);
    }
}
