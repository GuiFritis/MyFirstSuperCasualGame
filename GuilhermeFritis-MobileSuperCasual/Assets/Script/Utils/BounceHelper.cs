using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("AnimationScale")]
    public float scaleDur = .2f;
    public float scaleBounce = .2f;
    public Ease scaleEase = Ease.InCirc;

    public void Bounce(){
        transform.DOKill();
        transform.localScale = Vector3.one;
        transform.DOScale(scaleBounce, scaleDur).SetEase(scaleEase).SetLoops(2, LoopType.Yoyo);
    }

}
