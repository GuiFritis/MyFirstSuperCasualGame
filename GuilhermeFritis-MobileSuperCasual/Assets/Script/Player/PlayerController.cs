using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string enemyTag = "Enemy";

    private bool _canRun = true;
    private Vector3 _pos;

    void Start()
    {
        _canRun = true;
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
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag(enemyTag)){
            _canRun = false;
        }
    }
}
