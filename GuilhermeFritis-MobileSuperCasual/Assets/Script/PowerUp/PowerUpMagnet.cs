using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMagnet : PowerUpBase
{
    [Header("Magnet")]
    public float scaleMultiplier = 5f;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize(scaleMultiplier);
        PlayerController.Instance.SetPowerUpText("MAGNET");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize(1f);
        PlayerController.Instance.SetPowerUpText("");
    }
}
