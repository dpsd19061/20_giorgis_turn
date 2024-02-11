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
    private float Rspeed = 55f;
    public float nitro = 1;
    public GameObject BoostGauge;
    public GameObject carSprite;

    float gear1 = 55;
    float gear2 = 171;
    float gear3 = 342;
    float gear4 = 440;
    float reverse = 40;

    bool boostIsAvailable = false;
    float boostIncrease = 1.3f;

    int displaySpeed;
    public TMP_Text speedometer;

    bool timingHasStarted = false;
    bool raceFinished = false;
    float time = 0;
    float sec = 0;
    public float timeInSeconds = 0;
    int minutes = 0;
    public TMP_Text timerSec;
    public TMP_Text timerMin;

    public Animator animator;
    public bool steering = false;

    public AudioSource engine;
    public AudioSource nitrous;
    public AudioSource crash;

    public GameObject goldS;
    public GameObject silverS;
    public GameObject bronzeS;
    public GameObject failS;

    public GameObject Scene1;
    public GameObject Scene2;
    public GameObject Scene3;

    public static bool disablePause = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 0f;
    }

    void Update()
    {
        speed = rb.velocity.magnitude;
        
        //Changes the acceleration depending the speed
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

        //Steering and animation steering only when the car has some speed
        if (speed > 1f)
        {
            rb.transform.Rotate(0, Input.GetAxis("Horizontal") * Rspeed * Time.deltaTime, 0);

            if (Input.GetKey(KeyCode.A))
            {
                carSprite.transform.localEulerAngles = new Vector3(0, 180, 0);
                steering = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                carSprite.transform.localEulerAngles = new Vector3(0, 0, 0);
                steering = true;
            }
            else
            {
                steering = false;
            }
        }

        if(Input.GetAxis("Vertical") < 0)
        {
            acc = reverse;
        }

        //Displaying speed on the speedometer
        displaySpeed = (int)(speed * 3.6f);
        speedometer.text = displaySpeed.ToString();

        animator.SetBool("Steering", steering);

        Boost();

        Timing();

        EngineRevSound();

        PrizeScreen();
    }

    void FixedUpdate()
    {
        rb.velocity += rb.transform.forward * Input.GetAxis("Vertical") * acc * Time.fixedDeltaTime;
    }

    //Boost Function
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

        if (Input.GetKeyDown(KeyCode.Space) && nitro > 0)
        {
            nitrous.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            nitrous.Stop();
        }

        if (nitro < 1)
        {
            nitro += 0.05f * Time.deltaTime;
            BoostGauge.transform.localScale = new Vector3(1, nitro ,1);
        }
    }

    //Function for timing the car
    void Timing()
    {
        if (timingHasStarted)
        {
            time = Time.deltaTime;
            timeInSeconds += time;
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

    //Function for giving prizes depending on the time
    void PrizeScreen()
    {
        if (TrackSelection.selectedTrack == 1)
        {
            if ((raceFinished == true) && (timeInSeconds <= 85f))
            {
                goldS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
            else if ((raceFinished == true) && (timeInSeconds <= 90f))
            {
                silverS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
            else if ((raceFinished == true && timeInSeconds <= 95f))
            {
                bronzeS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
            else if ((raceFinished == true && timeInSeconds > 95f))
            {
                failS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
        }
        else if (TrackSelection.selectedTrack == 2)
        {
            if ((raceFinished == true) && (timeInSeconds <= 170f))
            {
                goldS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
            else if ((raceFinished == true) && (timeInSeconds <= 180f))
            {
                silverS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
            else if ((raceFinished == true && timeInSeconds <= 190f))
            {
                bronzeS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
            else if ((raceFinished == true && timeInSeconds > 190f))
            {
                failS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
        }
        else if (TrackSelection.selectedTrack == 3)
        {
            if ((raceFinished == true) && (timeInSeconds <= 510f))
            {
                goldS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
            else if ((raceFinished == true) && (timeInSeconds <= 540f))
            {
                silverS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
            else if ((raceFinished == true && timeInSeconds <= 570f))
            {
                bronzeS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
            else if ((raceFinished == true && timeInSeconds > 570f))
            {
                failS.SetActive(true);
                Time.timeScale = 0f;
                nitrous.Stop();
                engine.Stop();
            }
        }
    }

    //Sound for engine
    void EngineRevSound()
    {
        engine.pitch = (rb.velocity.magnitude/45) + 0.3f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "borders")
        {
            crash.Play();
        }

        if (collision.gameObject.tag == "sideroad")
        {
            rb.drag += 1f;
        }

        if (collision.gameObject.tag == "finishBound")
        {
            raceFinished = true;
            disablePause = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puddle")
        {
            rb.drag += 6f;
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
            rb.drag -= 1f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "puddle")
        {
            rb.drag -= 6f;
        }
    }

    public void continue1()
    {
        Scene1.SetActive(false);
        Scene2.SetActive(true);
    }

    public void continue2()
    {
        Scene2.SetActive(false);
        Scene3.SetActive(true);
    }

    public void continue3()
    {
        Scene3.SetActive(false);
        disablePause = false;
        Time.timeScale = 1f;
    }
}
