using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    public List<Transform> positions;

    public float moveDur = 1f;

    private int _index = 0;

    void Start()
    {
        _index = Random.Range(0, positions.Count);
        transform.position = positions[_index].position;
        NextIndex();
        StartCoroutine(StartMovement());
    }

    private void NextIndex(){
        _index++;
        if(_index >= positions.Count){
            _index = 0;
        }
    }

    private IEnumerator StartMovement(){
        float time = 0f;

        while(true){
            var currentPosition = transform.position;
            while(time < moveDur){

                transform.position = Vector3.Lerp(currentPosition, positions[_index].position, (time/moveDur));

                time += Time.deltaTime;
                yield return null;
            }          
            
            NextIndex();
            
            time = 0f;
            yield return null;
        }
    }
}
