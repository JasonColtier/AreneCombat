using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPiercing : MonoBehaviour
{


    public float Damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ennemi")
        {
            other.gameObject.GetComponentInParent<EnnemiLife>().ChangeHealth(Damage);
        }
    }
}
