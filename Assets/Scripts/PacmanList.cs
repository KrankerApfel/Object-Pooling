using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanList : MonoBehaviour
{
    private void Awake()
    {
        TAccessor<PacmanList>.Instance.AddItem(this);
        Debug.Log(TAccessor<PacmanList>.Instance.GetAllModules().Count);

    }

    private void OnDestroy()
    {
        TAccessor<PacmanList>.Instance.RemoveItem(this);
    }
}
