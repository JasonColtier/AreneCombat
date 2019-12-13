using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public float Damage;

    private void Start()
    {
        Debug.Log("my bullet do damage : " + Damage);
    }

    private void OnCollisionEnter(Collision collision)
    {

        
        Destroy(gameObject);
        // Debug.Log("collision : "+collision.gameObject.tag);

        if (collision.gameObject.tag == "Ennemi") { 

            collision.gameObject.GetComponentInParent<EnnemiLife>().ChangeHealth(Damage);
        }

    }
}
