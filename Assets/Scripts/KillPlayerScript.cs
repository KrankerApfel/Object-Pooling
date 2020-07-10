using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour
{
    private TAccessor<GhostScore> _ghostScore;
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
        if (_ghostScore == null)
        {
            _ghostScore = TAccessor<GhostScore>.Instance;
        }
        if (other.collider.CompareTag("Pacman"))
        {
            Destroy(other.gameObject);
        }

    }
}
