using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float jupmForce;

    public enum PlayerState { Alive, Dead };

    public PlayerState playerState;

    public int isGroundedTrigger = 0;

    [SerializeField]
    private float RotationSpeed;

    public bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out hit))
        //{
        //    Vector3 newDirection = Vector3.RotateTowards(transform.forward, hit.point, rotationSpeed * Time.deltaTime, 0.0f);
        //    Debug.Log("hit");

        //    transform.GetChild(0).transform.rotation = Quaternion.LookRotation(newDirection);
        //}

        //RaycastHit hit;
        //// Does the ray intersect any objects excluding the player layer
        //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
        //{

        //    Debug.Log("Did Hit");
        //}

        float deltaSpeed = Time.deltaTime * movementSpeed;
        float deltaRotSpeed = Time.deltaTime * rotationSpeed;



        //TESTER TRANSFOM . TRANSLATE

        int AxeForward = 0;
        int AxeSide = 0;
        if (Input.GetKey(KeyCode.Z))
            AxeForward = 1;
        if (Input.GetKey(KeyCode.S))
            AxeForward = -1;
        if (Input.GetKey(KeyCode.D))
            AxeSide = 1;
        if (Input.GetKey(KeyCode.Q))
            AxeSide = -1;

        Vector3 CurrentSpeed = rb.velocity;
        Vector3 MaxSpeedForward = AxeForward * movementSpeed * Vector3.forward;
        Vector3 MaxSpeedSide = AxeSide * movementSpeed * Vector3.right;

        Vector3 MaxSpeed = MaxSpeedForward + MaxSpeedSide;

        rb.AddForce(MaxSpeed - CurrentSpeed);

        //if (Input.GetKey(KeyCode.Z))
        //    rb.AddForce(transform.forward * deltaSpeed);
        //if (Input.GetKey(KeyCode.S))
        //    rb.AddForce(transform.forward * (-deltaSpeed));
        //if (Input.GetKey(KeyCode.D))
        //    rb.AddForce(new Vector3(deltaSpeed, 0, 0));
        //if (Input.GetKey(KeyCode.Q))
        //    rb.AddForce(new Vector3(-deltaSpeed, 0, 0));

        //if (Input.GetKey(KeyCode.D))
        //    transform.Rotate(new Vector3(0, deltaRotSpeed, 0));
        //if (Input.GetKey(KeyCode.Q))
        //    transform.Rotate(new Vector3(0, -deltaRotSpeed, 0));

        //if (Input.GetKeyDown(KeyCode.Space) && isGroundedTrigger > 0)
        //{
        //    rb.AddForce(new Vector3(0, jupmForce, 0));
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        isGroundedTrigger ++;
    }

    private void OnTriggerExit(Collider other)
    {
        isGroundedTrigger --;
    }
}
