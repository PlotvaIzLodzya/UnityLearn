using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Healable : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    public void Heal(int healAmount)
    {
        _health.IncreaseHealth(healAmount);
    }
}
