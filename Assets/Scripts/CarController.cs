using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    Rigidbody rb;
    public float acc = 15f;
    public float speed;
    public float Rspeed = 50f;

    int displaySpeed;
    public TMP_Text speedometer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        speed = rb.velocity.magnitude;
        
        if(speed <= 8f)
        {
            acc = 15f;
        }
        else if(speed > 8f && speed <= 25f)
        {
            acc = 40f;
        }
        else if (speed > 25f && speed <= 50f)
        {
            acc = 80f;
        }
        else if (speed > 50f)
        {
            acc = 100f;
        }

        if (speed > 0.01f)
        {
            rb.transform.Rotate(0, Input.GetAxis("Horizontal") * Rspeed * Time.deltaTime, 0);
        }

        if(Input.GetAxis("Vertical") < 0)
        {
            rb.drag = 1.8f;
        }
        else
        {
            rb.drag = 1.5f;
        }

        displaySpeed = (int)(speed * 3.6f);
        speedometer.text = displaySpeed.ToString();
    }

    void FixedUpdate()
    {
        rb.velocity += rb.transform.forward * Input.GetAxis("Vertical") * acc * Time.fixedDeltaTime;
    }
}
