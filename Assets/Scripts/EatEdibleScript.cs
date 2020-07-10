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
    
    //if colliding object is an edible, increase score and eat the edible, if it was a powerup increase speed up 
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Edible"))
        {
            GetComponent<PacmanScore>().Score++;
            try
            {
               GetComponent<NavMeshAgent>().speed +=  other.gameObject.GetComponent<SpeedPowerUp>().speedBonus;
            }
            catch(Exception e){}
            Destroy(other.gameObject);
        }
    }
}
