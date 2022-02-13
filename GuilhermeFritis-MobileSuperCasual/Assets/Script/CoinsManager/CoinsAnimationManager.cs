using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Padrao.Core.Singleton;
using DG.Tweening;
using System.Linq;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<ItemCollectableCoin> itens;

    [Header("AnimationScale")]
    public float scaleDur = .2f;
    public float scaleDelay = .2f;
    public Ease scaleEase = Ease.InCirc;
    [Header("AnimationRotation")]
    public float rotationDur = .2f;
    public Ease rotationEase = Ease.InBounce;

    private void Start(){
        itens = new List<ItemCollectableCoin>();
    }

    public void RegisterCoin(ItemCollectableCoin coin){
        if(!itens.Contains(coin) && coin != null){
            coin.transform.localScale = Vector3.zero;
            itens.Add(coin);
        }
    }

    public void StartAnimations(){        
        SortCoins();
        StartCoroutine(ScalePiecesByTime());
    }

    private IEnumerator ScalePiecesByTime(){
        foreach(var p in itens){
            p.transform.localScale = Vector3.zero;
        }

        yield return null;

        for(int i = 0; i < itens.Count; i++){
            itens[i].transform.DOScale(Vector3.one, scaleDur).SetEase(scaleEase);
            itens[i].transform.DORotate(Vector3.up*360*1.5f, rotationDur, RotateMode.FastBeyond360).SetEase(rotationEase);
            yield return new WaitForSeconds(scaleDelay);
        }

    }

    private void SortCoins(){
        itens = itens.OrderBy(
            x => Vector3.Distance(transform.position, x.transform.position)
        ).ToList();
    }

}
