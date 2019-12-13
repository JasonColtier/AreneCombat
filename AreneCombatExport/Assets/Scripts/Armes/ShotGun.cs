using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Arme
{

    [SerializeField]
    private List<Transform> bulletSpawnPoints = new List<Transform>();

    [SerializeField]
    private GameObject bulletPrefab;

    public override void Fire()
    {
        base.Fire();
        foreach(Transform t in bulletSpawnPoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, t.position, t.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(t.forward * bulletSpeed);
            bullet.GetComponent<Bullet>().Damage = (float)damage;

            Destroy(bullet, bulletLife);
        }
       
    }

}
