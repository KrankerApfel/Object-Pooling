using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Teleporter : MonoBehaviour
{
      private Vector3 _randomPosition;
      
      
      private void Awake()
      {
            _randomPosition = new Vector3(Random.Range(2,13),0,Random.Range(2,13));
            TAccessor<Teleporter>.Instance.AddItem(this);
      }

      private void OnDestroy()
      {
            TAccessor<Teleporter>.Instance.RemoveItem(this);
      }
      
      //when character enters teleporter, sends to a random location set at the beginning of the scene

      public void OnTriggerEnter(Collider other)
      {
            other.transform.position = _randomPosition;
      }
}
