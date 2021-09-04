using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] GameObject _centerOfUniverse;
    [SerializeField] float _moonCircleSpeed = 0.0005f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(_centerOfUniverse.transform.position,Vector3.right, _moonCircleSpeed);
    }
}
