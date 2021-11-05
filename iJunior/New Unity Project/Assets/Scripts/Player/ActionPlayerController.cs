using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Player), typeof(SpellBook))]
public class ActionPlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Player _player;
    private SpellBook _playerSpellBook;

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _playerSpellBook = GetComponent<SpellBook>();
        _playerInput = GetComponent<PlayerInput>();
        _player.Died += OnPlayerDied;
        _playerInput.KeyboardButtonPressed += ControllPlayer;
        _playerInput.CastSpellPressed += CastSpell;
    }

    private void OnDisable()
    {
        _playerInput.KeyboardButtonPressed -= ControllPlayer;
        _playerInput.CastSpellPressed -= CastSpell;
        _player.Died -= OnPlayerDied;
    }

    private void ControllPlayer(KeyCode input)
    {
        switch (input)
        {
            case KeyCode.D:
                LookRight();
                Move();
                break;
            case KeyCode.A:
                LookLeft();
                Move();
                break;
            case KeyCode.Space:
                _player.Jump();
                break;
            case KeyCode.E:
                _playerSpellBook.NextSpell();
                break;
            case KeyCode.Q:
                _playerSpellBook.PreviousSpell();
                break;
            default:
                break;
        }
    }

    public void Move()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _player.Speed);
    }

    public void CastSpell()
    {
        _playerSpellBook.CurrentSpell.Cast(_player.CastPoint);
    }

    public void LookRight()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void LookLeft()
    {
        transform.rotation = Quaternion.Euler(0,180,0);
    }

    private void OnPlayerDied() 
    {
        _playerInput.KeyboardButtonPressed -= ControllPlayer;
        _playerInput.CastSpellPressed -= CastSpell;
        _player.Died -= OnPlayerDied;
    }
}
