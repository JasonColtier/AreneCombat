using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private int Damage;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponentInParent<EnnemiLife>().ChangeHealth(Damage);
        }

    }
}
