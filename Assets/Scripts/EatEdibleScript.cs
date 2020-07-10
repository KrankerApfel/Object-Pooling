using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Edible"))
        {
            GetComponent<PacmanScore>().Score++;
            Destroy(other.gameObject);
        }
    }
}
