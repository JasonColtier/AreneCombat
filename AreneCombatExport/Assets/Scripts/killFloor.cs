using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killFloor : MonoBehaviour
{

    public Transform respanwPoint;

   private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ennemi")
        {
            Destroy(other.gameObject);

        }
        else if(other.tag == "Player")
        {
            other.transform.position = respanwPoint.position;
           
            other.GetComponent<LifeManager>().ChangeHealth(1);
              
           
        }
    }
}
