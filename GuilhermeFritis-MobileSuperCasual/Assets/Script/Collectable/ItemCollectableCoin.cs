using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemCollectableCoin : ItemCollectableBase
{

    public SOAnimation collectingMoveY;
    // public SOAnimation collectingFade;
    public float lerp = 5f;
    public bool collect = false;

    public void Update(){
        if(collect){
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);
        }
    }

    protected override void Collect()
    {
        if(audioSorce != null){
            audioSorce.Play();
        }
        collectingMoveY.DGAnimate(transform.DOMoveY(collectingMoveY.value , collectingMoveY.duration));
        collect = true;
        base.Collect();
    }
    protected override void OnCollect()
    {
        base.OnCollect();
    }
}
