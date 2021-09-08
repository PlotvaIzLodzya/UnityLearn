 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerControlls : PlayerMovement
{
    [SerializeField] float _speed = 5;
    [SerializeField] float _jumpForce = 490;
    private Rigidbody _playerRb;
    [SerializeField] int _maxJumpAmount1;
    [SerializeField] GameObject _player;


    private int gravityModifier = 4;

    public bool isPlayerReborning;


    // Start is called before the first frame update
    void Start()
    {
        SetMaxAmountJump(_maxJumpAmount1);
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerReborning == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            MovePlayer(_speed, verticalInput, horizontalInput);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerJump(_playerRb, _jumpForce);
            }

        }
    }
}
