using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSpawningAnimation : MonoBehaviour
{
    
    public SOAnimation playerScaleSO;

    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void Spawn(){
        playerScaleSO.DGAnimate(transform.DOScale(playerScaleSO.value, playerScaleSO.duration));
        Invoke(nameof(StartRun), playerScaleSO.duration);
    }

    private void StartRun(){
        PlayerController.Instance.StartRun();
    }

}
