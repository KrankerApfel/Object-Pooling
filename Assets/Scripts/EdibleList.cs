using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//reference to list of all edibles to easily have access to
public class EdibleList : MonoBehaviour
{

    private void Awake()
    {
        TAccessor<EdibleList>.Instance.AddItem(this);
    }

    private void OnDestroy()
    {
        TAccessor<EdibleList>.Instance.RemoveItem(this);
    }

}
