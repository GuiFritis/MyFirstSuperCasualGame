using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Padrao.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string enemyTag = "Enemy";
    public string endLineTag = "EndLine";

    public GameObject endScreen;

    [Header("Text")]
    public TextMeshPro uiTextPowerUp;

    private bool _canRun = false;
    private Vector3 _pos;
    private float _curSpeed;
    private bool _invencible = false;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if(_canRun){
            Move();
            WalkForward();
        }
    }

    private void Move(){        
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);    
    }

    private void WalkForward(){
        transform.Translate(transform.forward * _curSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!_invencible && collision.transform.CompareTag(enemyTag)){
            _canRun = false;
            CallEndGame();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(endLineTag)){
            _canRun = false;
            CallEndGame();
        }
    }

    public void StartRun(){
        _canRun = true;
    }

    public void CallEndGame(){
        endScreen.SetActive(true);
    }

    #region POWER_UPS
    public void SetPowerUpText(string s){
        uiTextPowerUp.text = s;
    }

    public void SpeedUp(float speedMultiplier){
        _curSpeed *= speedMultiplier;
    }

    public void ResetSpeed(){
        _curSpeed = speed;
    }

    public void SetInvencible(bool invencible){
        _invencible = invencible;
    }

    public void SetFlight(float flightHeight, float duration, float animationDur, Ease ease){

        transform.DOMoveY(_startPosition.y + flightHeight, animationDur).SetEase(ease);

        Invoke(nameof(Land), duration);
    }

    public void Land(){
        transform.DOMoveY(_startPosition.y, .3f);
    }
    #endregion

}
