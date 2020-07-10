using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EatEdibleScriptSystem : MonoBehaviour
{
    private TAccessor<EdibleList> _edibles;
    private TAccessor<PacmanScore> _score;

    //if colliding object is an edible, increase score and eat the edible, if it was a powerup increase speed up 
    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Edible")) return;
        GetComponent<PacmanScore>().Score++;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        try
        {
            GetComponent<NavMeshAgent>().speed +=  other.gameObject.GetComponent<SpeedPowerUp>().speedBonus;
        }
        catch(Exception e){}
        Destroy(other.gameObject);

    }
}
