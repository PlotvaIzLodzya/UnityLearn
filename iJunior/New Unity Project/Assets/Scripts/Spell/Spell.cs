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
    public int DamagePerUpgrade => _damagePerUpgrade;

    public abstract void Cast(Transform castPoint);

    public void IncreaseDamage(int damage)
    {
        Projectile.IncreaseDamage(damage);
    }
}
