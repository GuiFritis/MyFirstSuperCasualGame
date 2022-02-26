using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtParticle : MonoBehaviour
{
    public GameObject curArt;

    public void ChangeParticle(GameObject particle){
        if(curArt != null){
            Destroy(curArt);
        }

        curArt = Instantiate(particle, transform);
        curArt.transform.localPosition = Vector3.zero;
    }
}
