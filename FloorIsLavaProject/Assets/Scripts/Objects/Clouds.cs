using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MovingCalculator
{

    [SerializeField] float _speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovingForwardInWorld(_speed);
    }
}
