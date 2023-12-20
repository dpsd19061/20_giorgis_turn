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
    public float nitro = 1;
    public GameObject BoostGauge;

    float gear1 = 15f;
    float gear2 = 40f;
    float gear3 = 80f;
    float gear4 = 100f;
    float reverse = 10f;

    bool boostIsAvailable = false;
    float boostIncrease = 1.2f;

    int displaySpeed;
    public TMP_Text speedometer;

    bool timingHasStarted = false;
    float time = 0;
    float sec = 0;
    int minutes = 0;
    public TMP_Text timerSec;
    public TMP_Text timerMin;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        speed = rb.velocity.magnitude;
        
        if(speed <= 8f)
        {
            if (boostIsAvailable)
            {
                acc = gear1 * boostIncrease;
            }
            else
            {
                acc = gear1;
            }
        }
        else if(speed > 8f && speed <= 25f)
        {
            if (boostIsAvailable)
            {
                acc = gear2 * boostIncrease;
            }
            else
            {
                acc = gear2;
            }
        }
        else if (speed > 25f && speed <= 50f)
        {
            if (boostIsAvailable)
            {
                acc = gear3 * boostIncrease;
            }
            else
            {
                acc = gear3;
            }
        }
        else if (speed > 50f)
        {
            if (boostIsAvailable)
            {
                acc = gear4 * boostIncrease;
            }
            else
            {
                acc = gear4;
            }
        }

        if (speed > 0.01f)
        {
            rb.transform.Rotate(0, Input.GetAxis("Horizontal") * Rspeed * Time.deltaTime, 0);
        }

        if(Input.GetAxis("Vertical") < 0)
        {
            acc = reverse;
        }


        displaySpeed = (int)(speed * 3.6f);
        speedometer.text = displaySpeed.ToString();

        Boost();

        Timing();
    }

    void FixedUpdate()
    {
        rb.velocity += rb.transform.forward * Input.GetAxis("Vertical") * acc * Time.fixedDeltaTime;
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.Space) && nitro > 0)
        {
            nitro -= 0.5f * Time.deltaTime;
            boostIsAvailable = true;
        }
        else 
        {
            boostIsAvailable = false;
        }

        if (nitro < 1)
        {
            nitro += 0.05f * Time.deltaTime;
            BoostGauge.transform.localScale = new Vector3(1, nitro ,1);
        }
    }

    void Timing()
    {
        if (timingHasStarted)
        {
            time = Time.deltaTime;
            sec += time;
            if(sec > 60f)
            {
                sec = 0;
                minutes += 1;
            }
            timerSec.text = sec.ToString("00.000");
            timerMin.text = minutes.ToString("00");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sideroad")
        {
            rb.drag += 0.2f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puddle")
        {
            rb.drag += 3f;
        }

        if (other.gameObject.tag == "start")
        {
            timingHasStarted = true;
        }

        if (other.gameObject.tag == "finish")
        {
            timingHasStarted = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "sideroad")
        {
            rb.drag -= 0.2f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "puddle")
        {
            rb.drag -= 3f;
        }
    }
}
