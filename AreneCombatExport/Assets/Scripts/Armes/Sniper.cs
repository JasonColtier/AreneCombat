using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Arme
{

    [SerializeField]
    private Transform bulletSpawnPoints;

    [SerializeField]
    private GameObject bulletPrefab;

    public override void Fire()
    {
        base.Fire();
        
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoints.position, bulletSpawnPoints.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoints.forward * bulletSpeed);
            bullet.GetComponent<BulletPiercing>().Damage = (int)damage;
            Destroy(bullet, bulletLife);
       
    }

}
