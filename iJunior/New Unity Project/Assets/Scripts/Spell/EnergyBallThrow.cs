using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallThrow : Spell
{
    public override void Cast(Transform castPoint)
    {
        var projectile = Instantiate(Projectile, castPoint.position, castPoint.rotation);
        projectile.SetDamage(_damage);
    }
}
