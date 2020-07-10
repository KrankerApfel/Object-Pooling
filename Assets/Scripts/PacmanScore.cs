
using UnityEngine;

public class PacmanScore : MonoBehaviour
{
      public int score = 0;
      private void Awake()
      {
            TAccessor<PacmanScore>.Instance.AddItem(this);
      }
    
      private void OnDestroy()
      {
            TAccessor<PacmanScore>.Instance.RemoveItem(this);
      }

   
}
