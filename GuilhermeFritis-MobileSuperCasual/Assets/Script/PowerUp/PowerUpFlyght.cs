using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFlyght : PowerUpBase
{
    [Header("Flyght")]
    public float FlyghtHeight = 2f;
    public float animationDur = .3f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.InSine;    

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetFlight(FlyghtHeight, duration, animationDur, ease);
    }
}
