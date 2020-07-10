using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerScriptSystem : MonoBehaviour
{
    //if ghost collides with pacman, kill it
    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Pacman")) return;
        GetComponent<GhostScore>().Score+=5;
        Destroy(other.gameObject);
    /*
        On a essayez de ne pas utiliser les tags ni les GetComponent mais on a pas réussi
        if (TAccessor<GhostScore>.Instance.GetModuleByRef(other.gameObject) != null)
        {
            GetComponent<GhostScore>().Score+=5;
            Destroy(other.gameObject);
        }*/

    }
}
