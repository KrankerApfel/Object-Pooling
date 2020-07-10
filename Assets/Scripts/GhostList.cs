﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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