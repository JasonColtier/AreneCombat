using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{

    public MovePlayer player;
    Rigidbody rb;

    public float speed = 1f;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject explo = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explo, 2);
        }
    }

}
