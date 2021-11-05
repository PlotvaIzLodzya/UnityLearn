using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] protected Projectile Projectile;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _damagePerUpgrade;
    [SerializeField] protected int _damage;

    public string Label => _label;
    public Sprite Icon => _icon;

    public abstract void Cast(Transform castPoint);

    public void IncreaseDamage()
    {
        _damage += _damagePerUpgrade;
    }
}
