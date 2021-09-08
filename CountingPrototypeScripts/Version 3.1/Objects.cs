using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Objects : MonoBehaviour
{

    private Vector3 _screenPoint;
    private Rigidbody _objectRigidbody;
    private bool _isDragged;
    private GameManager _gameManagerScript;
    //[SerializeField] private float _stopForceMultiplier = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        _objectRigidbody = GetComponent<Rigidbody>();
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ConstrainObject();
    }

    private void OnMouseDown()
    {
        _isDragged = true;
    }
    public void OnMouseDrag()
    {
        if (_gameManagerScript.isPreparationTime == false && _isDragged)
        {
            _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Vector3 forceDirection = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.x)) - transform.position;

            _objectRigidbody.AddForce(forceDirection * _gameManagerScript._forceMultiplier, ForceMode.Force);
        }
    }

    private void OnMouseUp()
    {
        _isDragged = false;
    }

    private void ConstrainObject()
    {
        if (_isDragged)
            _objectRigidbody.velocity = _objectRigidbody.velocity.normalized;

        // Can't Make it work as i want it
        //if (_objectRigidbody.velocity.magnitude > _maxSpeed)
        //    _objectRigidbody.AddForce(-_objectRigidbody.velocity * (_objectRigidbody.velocity.magnitude - _maxSpeed), ForceMode.Acceleration);

        if (_objectRigidbody.velocity.magnitude > _gameManagerScript._maxSpeed)
        {
            _objectRigidbody.velocity = _objectRigidbody.velocity.normalized * _gameManagerScript._maxSpeed;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        _isDragged = false;
    }
}
