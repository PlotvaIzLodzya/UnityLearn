using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _castPoint;  

    private Health _health;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody;

    public float Speed => _speed;
    public Transform CastPoint => _castPoint;

    public event UnityAction Died;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _health = GetComponent<Health>();
        _health.HealthRanOut += Die;
    }

    private void OnDisable()
    {
        _health.HealthRanOut -= Die;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            _isGrounded = true;
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _isGrounded = false;
            _rigidbody.velocity = new Vector2(0, _jumpForce);
        }
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
