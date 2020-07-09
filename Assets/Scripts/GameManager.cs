using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Updater updater;

    // Update is called once per frame
    void Update()
    {
       updater.SystemUpdate(); 
    }
}
