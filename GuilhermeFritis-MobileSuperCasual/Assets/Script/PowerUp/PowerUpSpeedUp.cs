using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Speed Up")]
    public float speedMultiplier = 1.5f;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SpeedUp(speedMultiplier);
        PlayerController.Instance.SetPowerUpText("FAST");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
        PlayerController.Instance.SetPowerUpText("");
    }
}
