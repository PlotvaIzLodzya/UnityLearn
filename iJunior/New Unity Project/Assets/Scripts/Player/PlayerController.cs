using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float playerSpeed)
    {
        transform.Translate(Vector2.right * Time.deltaTime * playerSpeed);
    }

    public void Jump(Player player)
    {
        if (player.IsGrounded)
        {
            player.SetIsGrounded();
            _playerRigidbody.velocity = new Vector2(0, player.JumpForce);
        }
    }

    public void CastSpell(Player player)
    {
        player.CastSpell();
    }

    public void LookRight()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void LookLeft()
    {
        transform.rotation = Quaternion.Euler(0,180,0);
    }

    public void NextSpell(Player player)
    {
        player.NextSpell();
    }

    public void PreviousSpell(Player player)
    {
        player.PreviousSpell();
    }
}
