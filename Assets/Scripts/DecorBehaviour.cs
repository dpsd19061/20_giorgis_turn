using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorBehaviour : MonoBehaviour
{
    //public GameObject car;
    public Transform car;

    void Update()
    {
        //transform.Rotate(0, car.transform.rotation.y, 0);
        transform.LookAt(car);
    }
}
