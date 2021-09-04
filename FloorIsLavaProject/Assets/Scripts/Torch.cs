using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] ParticleSystem _fire;
    // Start is called before the first frame update
    void Start()
    {
        _fire.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
