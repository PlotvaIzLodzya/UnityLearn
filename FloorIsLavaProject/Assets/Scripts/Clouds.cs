using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] UtilityScripts _utility;
    [SerializeField] float _speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _utility = GetComponent<UtilityScripts>();
        if (_utility == null)
            _utility = FindObjectOfType<UtilityScripts>().GetComponent<UtilityScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        _utility.MovingForwardInWorld(_speed);
    }
}
