using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour
{
    private void Awake()
    {
        TAccessor<KillPlayerScript>.Instance.AddItem(this);
    }

    private void OnDestroy()
    {
        TAccessor<KillPlayerScript>.Instance.RemoveItem(this);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Pacman"))
        {
            Destroy(other.gameObject);
        }
    }
}
