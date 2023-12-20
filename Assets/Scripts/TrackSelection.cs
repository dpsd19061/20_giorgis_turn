using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSelection : MonoBehaviour
{
    public static int selectedTrack = 0;

    public void Track1()
    {
        selectedTrack = 1;
        SceneManager.LoadScene("Select Car");
    }

    public void Track2()
    {
        selectedTrack = 2;
        SceneManager.LoadScene("Select Car");
    }

    public void Track3()
    {
        selectedTrack = 3;
        SceneManager.LoadScene("Select Car"); 
    }
}
