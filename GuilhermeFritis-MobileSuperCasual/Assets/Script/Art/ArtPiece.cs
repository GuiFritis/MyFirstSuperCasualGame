using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject curArt;

    public void ChangePiece(GameObject piece){
        if(curArt != null){
            Destroy(curArt);
        }

        curArt = Instantiate(piece, transform);
        curArt.transform.localPosition = Vector3.zero;
    }
}
