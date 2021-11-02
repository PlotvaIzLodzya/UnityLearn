using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEnergyBall : Spell
{
    public override void Cast(Transform castPoint)
    {
        Instantiate(Projectile, castPoint.position, castPoint.rotation);
    }
}
