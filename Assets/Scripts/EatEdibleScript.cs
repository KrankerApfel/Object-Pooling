using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EatEdibleScript : MonoBehaviour
{
    
    private void Awake()
    {
        TAccessor<EatEdibleScript>.Instance.AddItem(this);
    }

    private void OnDestroy()
    {
        TAccessor<EatEdibleScript>.Instance.RemoveItem(this);
    }
    


}
