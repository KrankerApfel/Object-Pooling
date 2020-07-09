using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdater
{
    void SystemUpdate();
}


public class Updater : IUpdater
{
    public void SystemUpdate()
    {
        TAccessor<int> intList = TAccessor<int>.Instance;
        TAccessor<float> floatList = TAccessor<float>.Instance;
        TAccessor<int> intList2 = TAccessor<int>.Instance;
        TAccessor<Entity> entities = TAccessor<Entity>.Instance;
        TAccessor<FollowTarget> followTargets = TAccessor<FollowTarget>.Instance;
        
        //make a method in accessor to fill it in
        //modules are monobehaviors that you can fill in data with 
        foreach (var module in entities.GetAllModules())
        {
            GameObject entity = module.obj.gameObject;
            //GameObject entity = module.Value.Gameobject; 
        }
        
        //function so that all ghosts follow pacman 
        foreach (var module in followTargets.GetAllModules())
        {
            module.navMeshAgent.destination = module.playerPosition.position;
        }
    }
}

/*
Public class MyUpdater : IUpdater
{
    Public void SystemUpdate()
    {
        TAccessor<MyModule> myModuleAccessor = TAccessor<MyModule>.Instance();
        TAccessor<MyOhterModule> myOtherModuleAccessor = TAccessor<MyOhterModule>.Instance();
        Foreach(var module in myModuleAccessor.GetAllModules())
        {
            GameObject myEntity = module.Value.GameObject;
            MyOtherModule otherModule = myModuleAccessor.TryGetModule(myEntity);
            If(otherModule != null)
            DoSomething();
        }
    }
}*/