using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public int speedBonus = 3;
    private void Awake()
    {
        TAccessor<SpeedPowerUp>.Instance.AddItem(this);
    }

    private void OnDestroy()
    {
        TAccessor<SpeedPowerUp>.Instance.RemoveItem(this);
    }

}
