using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScore : MonoBehaviour
{    
    private void Awake()
    {
        TAccessor<GhostScore>.Instance.AddItem(this);
    }

    private void OnDestroy()
    {
        TAccessor<GhostScore>.Instance.RemoveItem(this);
    }

}
