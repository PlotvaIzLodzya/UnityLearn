using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private ParticleSystem _shootEffect;

    void Start()
    {
        _shootEffect = GetComponent<ParticleSystem>();
    }

    public void Emit()
    {
        _shootEffect.Emit(1);
    }

    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
}
