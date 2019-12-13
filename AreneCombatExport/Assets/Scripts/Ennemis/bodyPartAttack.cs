using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyPartAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.root.GetComponent<WarriorController>().Attack(other.gameObject);
        }
    }
}
