using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    [SerializeField]
    private Transform start, end;

    [SerializeField]
    [Range(0,1)]
    private float t;

    [SerializeField]
    private AnimationCurve courbe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //t = (Mathf.Sin(Time.time) + 1) / 2;

        //t += Time.deltaTime;
        //t = Mathf.PingPong(Time.time, 1);

        t = courbe.Evaluate(Time.time);
        transform.position = Vector3.Lerp(start.position, end.position, t);

        GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.blue, Color.red, t);
    }
}
