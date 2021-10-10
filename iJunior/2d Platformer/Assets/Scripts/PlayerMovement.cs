using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isFacingRight = true;
    private Animator _animator;
    private Rigidbody2D _playerRigidBody;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * _speed * Mathf.Abs(xAxis));

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _playerRigidBody.AddForce(Vector2.up * _jumpForce,ForceMode2D.Impulse);
            _isGrounded = false;
        }

        _animator.SetFloat("speed", Mathf.Abs(xAxis));

        if (xAxis > 0 && _isFacingRight)
        {
            Flip();
        }
        else if (xAxis < 0 && !_isFacingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0, 180f, 0);
    }
}
