using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallMover : MonoBehaviour
{
    private Ball _ball;

    private void Start()
    {
        _ball = GetComponent<Ball>();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _ball.Speed * Time.deltaTime);
    }
}
