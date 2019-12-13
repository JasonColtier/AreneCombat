using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{

    public List<Vector3> positionList = new List<Vector3>();
    public List<Quaternion> rotationList = new List<Quaternion>();

    bool rewindTime = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!rewindTime)
        {
            positionList.Add(transform.position);
            rotationList.Add(transform.rotation);
        }

        if (Input.GetMouseButtonDown(1))
        {
            rewindTime = true;
        }
        if (rewindTime && positionList.Count - 1 > 0)
        {
            transform.position = positionList[positionList.Count -1];
            transform.rotation = rotationList[rotationList.Count - 1];
            positionList.RemoveAt(positionList.Count - 1);
            rotationList.RemoveAt(rotationList.Count - 1);

            if (positionList.Count - 1 == 0)
            {
                rewindTime = false;
                
                GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            }
        }
        
    }
}
