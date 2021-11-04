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
            if (collider.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                Vector2 awayVector = enemy.transform.position - castPoint.position;

                enemy.AddForce(awayVector.normalized, pushForce);
            }
        }
    }
}
