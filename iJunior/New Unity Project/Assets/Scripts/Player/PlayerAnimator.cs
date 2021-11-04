using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{
    private Player _player;
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _player.Died += PlayDeathAnimation;
    }

    private void OnDisable()
    {
        _player.Died -= PlayDeathAnimation;
    }

    public void PlayDeathAnimation()
    {
        _animator.Play(AnimatorPlayerController.States.Death);
    }
}
