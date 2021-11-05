using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Spell
{
    [SerializeField] private float _radius;
    [SerializeField] private float pushForce;

    public override void Cast(Transform castPoint)
    {
        Instantiate(Projectile, castPoint.position, Quaternion.identity);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(castPoint.position, _radius);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Damagable damagable) && collider.gameObject.TryGetComponent(out Player player) == false)
            {
                damagable.TakeDamage(_damage);
                
                if(damagable.gameObject.TryGetComponent<Pushable>(out Pushable pushable))
                {
                    Vector2 awayVector = damagable.transform.position - castPoint.position;
                    pushable.Push(awayVector.normalized, pushForce);
                }
            }
        }
    }
}
