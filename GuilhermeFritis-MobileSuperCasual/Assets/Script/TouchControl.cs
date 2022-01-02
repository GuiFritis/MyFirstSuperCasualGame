using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public float speedMultiplier = 10f;

    private Vector2 _mousePos = Vector2.zero;
    private float _speed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){
        if(Input.GetMouseButton(0)){
            _speed = Input.mousePosition.x - _mousePos.x;
        }
        _mousePos = Input.mousePosition;

        transform.position += Vector3.right * Time.deltaTime * _speed;
    }
}
