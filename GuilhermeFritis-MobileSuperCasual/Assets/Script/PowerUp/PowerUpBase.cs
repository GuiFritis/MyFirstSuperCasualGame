using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [Header("Power Up")]
    public float duration = 5f;
    protected override void OnCollect()
    {
        PlayerController.Instance.Bounce();
        base.OnCollect();
        StartPowerUp();
    }

    protected virtual void StartPowerUp(){
        Debug.Log("Picked Up PowerUp");
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp(){

    }

}
