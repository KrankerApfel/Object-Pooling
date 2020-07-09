using UnityEngine;
public class PoolableObject : MonoBehaviour
{
   // To know if this object is used in game or inactive in pool.
   public bool IsActive()
   {
      return gameObject.activeInHierarchy;
   }
   public void Init()
   {
      gameObject.SetActive(true);
   }
   public void DeInit()
   {
      gameObject.SetActive(false);
   }
}
