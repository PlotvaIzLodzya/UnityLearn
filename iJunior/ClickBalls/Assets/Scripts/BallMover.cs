using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallMover : MonoBehaviour
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private Ball _ball;
    private float _speed;

    private void Start()
    {
        _ball = GetComponent<Ball>();
        _speed = Random.Range(_minSpeed, _maxSpeed);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    public void IncreaseSpeed(float speed)
    {
        _minSpeed += speed;
        _maxSpeed += speed;
    }
}
