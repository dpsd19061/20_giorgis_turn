using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody rb;
    public float acc = 10f;
    public float Rspeed = 50f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(rb.velocity.z > 1 || rb.velocity.z < -1 && rb.velocity.x > 1 || rb.velocity.x < -1)
        {
            rb.transform.Rotate(0, Input.GetAxis("Horizontal") * Rspeed * Time.deltaTime, 0);
        }
        
    }

    void FixedUpdate()
    {
        rb.velocity += /*new Vector3(0, 0, */rb.transform.forward * Input.GetAxis("Vertical") * acc * Time.fixedDeltaTime;
        //rb.angularVelocity = new Vector3(0, Input.GetAxis("Horizontal") * Rspeed * Time.fixedDeltaTime, 0);
    }
}
