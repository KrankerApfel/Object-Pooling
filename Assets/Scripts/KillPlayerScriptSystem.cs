using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerScriptSystem : MonoBehaviour
{
    //if ghost collides with pacman, kill it
    private void OnCollisionEnter(Collision other)
    {
      
        if (other.collider.CompareTag("Pacman"))
        {
            GetComponent<GhostScore>().Score+=5;
            Destroy(other.gameObject);
        }

    }
}
