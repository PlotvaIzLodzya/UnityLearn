using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pushable : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Push(Vector3 direction, float force)
    {
        _rigidbody2D.AddForce(direction * force);
    }
}
