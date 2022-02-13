using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{

    public float dur = 1f;
    public Color startColor = Color.white;
    public MeshRenderer mesh;

    private Color _targetColor;

    void OnValidate()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        _targetColor = mesh.materials[0].GetColor("_Color");
        LerpColor();
    }

    private void LerpColor(){
        mesh.materials[0].SetColor("_Color", startColor);
        mesh.materials[0].DOColor(_targetColor, dur).SetDelay(.5f);
    }

}
