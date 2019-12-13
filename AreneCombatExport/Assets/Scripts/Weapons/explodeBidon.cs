using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeBidon : MonoBehaviour
{

    public enum BombType { Click, Timer, Touch}

    [SerializeField]
    private BombType bombType;

   
    
    [SerializeField]
    private GameObject explosion;
    
    [SerializeField]
    private float explosionPower;

    [SerializeField]
    private float scale;

    [SerializeField]
    private float TimerCountDown = 0;

    bool startExplosion = false;
    bool exploded = false;
    float time = 0;
    List<GameObject> objectsInTriggerList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if(bombType == BombType.Timer)
        {
            startExplosion = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && bombType == BombType.Click)
        {
            startExplosion = true;
        }

        if (startExplosion)
        {
            float newScale = Mathf.Sin(time) * scale;
            transform.localScale += new Vector3(newScale, newScale, newScale);
            time += Time.deltaTime;
            if(time > TimerCountDown)
            {
                exploded = true;

                GameObject explo = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(explo, 2);
               
                if(bombType != BombType.Click)
                {
                    Destroy(gameObject);
                }
                else
                {
                    startExplosion = false;
                }

                foreach (GameObject monObjet in objectsInTriggerList)
                {
                    if(monObjet != null)
                    {
                        Vector3 directionForce = monObjet.transform.position - transform.position;
                        monObjet.GetComponent<Rigidbody>().AddForce(directionForce * explosionPower);
                    }              
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(bombType == BombType.Touch && collision.gameObject.tag == "Player")
        {
            startExplosion = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        objectsInTriggerList.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        objectsInTriggerList.Remove(other.gameObject);
    }
}
