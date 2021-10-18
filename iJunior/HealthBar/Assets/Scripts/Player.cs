using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class Player : MonoBehaviour
{
    private Health _health;

    public void GetHeal(float healAmount)
    {
        _health.Change(healAmount);
    }

    public void GetDamage(float damageAmount)
    {
        _health.Change(-damageAmount);
    }

    private void Start()
    {
        _health = GetComponent<Health>();
    }
}
