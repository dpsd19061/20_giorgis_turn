using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorBehaviour : MonoBehaviour
{
    public Transform car;
    //For the trees and bushes, so that they always face the car an the camera
    void Update()
    {
        transform.LookAt(car);
    }
}
