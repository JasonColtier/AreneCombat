using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target1;
    
    [SerializeField]
    private Transform target2;

    [SerializeField]
    private float speedCamera = 5;

    [SerializeField]
    private float height = 5;

    // Update is called once per frame
    void Update()
    {
        Vector3 t1 = target1.position;
        Vector3 t2 = target2.position;

        float distance = Vector3.Distance(t1, t2);

        Vector3 milieu = Vector3.Lerp(t1, t2, 0.5f) + new Vector3(0, distance + height, 0); ;

        transform.position = Vector3.Lerp(transform.position, milieu, Time.deltaTime * speedCamera);
    }
}
