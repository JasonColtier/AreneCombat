using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Arme
{

    [SerializeField]
    private Transform bulletSpawnPoint;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private bool usesPiercingBullets;

    public override void Fire()
    {
        base.Fire();

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed);

        if (usesPiercingBullets)
        {
            bullet.GetComponent<BulletPiercing>().Damage = (float)damage;
        }
        else
        {
            bullet.GetComponent<Bullet>().Damage = (float)damage;
        }

        Destroy(bullet, bulletLife);
    }

}
