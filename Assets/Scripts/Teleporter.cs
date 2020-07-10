using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Teleporter : MonoBehaviour
{
      public Vector3 randomPosition;
      
      private void Awake()
      {
            randomPosition = new Vector3(Random.Range(2,13),0,Random.Range(2,13));
            TAccessor<Teleporter>.Instance.AddItem(this);
      }

      private void OnDestroy()
      {
            TAccessor<Teleporter>.Instance.RemoveItem(this);
      }

      public void OnTriggerEnter(Collider other)
      {
            other.transform.position = randomPosition;
      }
}
