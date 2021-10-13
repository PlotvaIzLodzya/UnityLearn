using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitButton : MonoBehaviour
{
    [SerializeField] private float _damageAmount = 10;

    public void GiveDamage(Player player)
    {
        player.GetDamage(_damageAmount);
    }
}
