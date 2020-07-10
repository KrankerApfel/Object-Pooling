using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interface for updaters
public interface IUpdater
{
    void SystemUpdate();
    void InitAccessors();
}