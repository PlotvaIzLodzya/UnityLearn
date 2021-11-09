using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRender : MonoBehaviour
{
    private Material _material;
    private Color _color;

    public Color Color => _color;

    private void Start()
    {
        _color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        _material = GetComponent<Renderer>().material;
        _material.SetColor("_Color", _color);
    }
}
