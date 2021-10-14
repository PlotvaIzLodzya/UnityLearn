using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Health Health;

    public void GetHeal(float healAmount)
    {
        StartCoroutine(Health.Change(healAmount));
    }

    public void GetDamage(float damageAmount)
    {
        StartCoroutine(Health.Change(-damageAmount));
    }
}
