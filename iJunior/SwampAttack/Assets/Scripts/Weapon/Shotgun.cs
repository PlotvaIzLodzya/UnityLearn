using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private int _bulletAmount = 3;
    private int _angleBetweenBullet = 30;

    public override void Shoot(Transform shootPoint)
    {
        for(int i = 0; i< _bulletAmount; i++)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.Euler(0, 0, -_angleBetweenBullet + i * _angleBetweenBullet));
        }
    }
}
