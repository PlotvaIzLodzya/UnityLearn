using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _healAmount = 10;
    [SerializeField] private float _damageAmount = 10;
    [SerializeField] private Health _health;

    public void GetHeal()
    {
        StartCoroutine(_health.Change(_healAmount));
    }


    public void GetDamage()
    {
        StartCoroutine(_health.Change(-_damageAmount));
    }


}
