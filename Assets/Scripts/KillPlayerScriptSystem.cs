using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerScriptSystem : MonoBehaviour
{
    //if ghost collides with pacman, kill it
    private void OnCollisionEnter(Collision other)
    {
        
        if (TAccessor<GhostScore>.Instance.GetModuleByRef(other.gameObject) != null)
        {
            GetComponent<GhostScore>().Score+=5;
            Destroy(other.gameObject);
        }

    }
}
