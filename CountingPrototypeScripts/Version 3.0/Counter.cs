using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Counter : MonoBehaviour
{
    private GameManager _gameManagerScript;
    public BoxCollider _trashcanTrigger;
    private Collider[] _trashcan;
    public int _count;
    private Vector3 _trashcanTriggerSize;
    private Vector3 _trashCanCenter;

    private void Start()
    {
        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        _trashcanTrigger = GetComponent<BoxCollider>();
        _trashcanTriggerSize = _trashcanTrigger.bounds.size;
        _trashCanCenter = _trashcanTrigger.bounds.center;
    }

    private void Update()
    {
        CountingObjectsInTrashCan();
    }

    private void CountingObjectsInTrashCan()
    {
        _trashcan = Physics.OverlapBox(_trashCanCenter, _trashcanTriggerSize / 2.0f);
        _gameManagerScript._count = _trashcan.Length-1;
    }

}
