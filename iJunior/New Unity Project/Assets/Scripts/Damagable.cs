using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Damagable : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    public void TakeDamage(int damage)
    {
        _health.DecreaseHealth(damage);
    }
}
