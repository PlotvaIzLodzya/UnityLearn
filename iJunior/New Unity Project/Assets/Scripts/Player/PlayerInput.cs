using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController),typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player _player;
    private PlayerController _playerMover;

    private void OnEnable()
    {
        _playerMover = GetComponent<PlayerController>();
        _player = GetComponent<Player>();
        _player.Died += Disable;
    }

    private void OnDisable()
    {
        _player.Died -= Disable;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _playerMover.LookRight();
            _playerMover.Move(_player.Speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
             _playerMover.LookLeft();
            _playerMover.Move(_player.Speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            _playerMover.Jump(_player);

        if (Input.GetMouseButtonDown(0))
            _playerMover.CastSpell(_player);

        if (Input.GetKeyDown(KeyCode.E))
            _playerMover.NextSpell(_player);

        if (Input.GetKeyDown(KeyCode.Q))
            _playerMover.PreviousSpell(_player);
    }

    private void Disable()
    {
        this.enabled = false;
    }
}
