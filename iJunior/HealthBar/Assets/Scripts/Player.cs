using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void GetHeal(float healAmount)
    {
        StartCoroutine(_health.Change(healAmount));
    }


    public void GetDamage(float damageAmount)
    {
        StartCoroutine(_health.Change(-damageAmount));
    }


}
