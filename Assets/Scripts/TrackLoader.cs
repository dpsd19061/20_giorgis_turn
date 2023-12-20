using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackLoader : MonoBehaviour
{
    public void GetInCar()
    {
        if(TrackSelection.selectedTrack == 1)
        {
            SceneManager.LoadScene("Track1");
        }
        else if (TrackSelection.selectedTrack == 2)
        {
            SceneManager.LoadScene("Track2");
        }
        else if (TrackSelection.selectedTrack == 3)
        {
            SceneManager.LoadScene("Track3");
        }
    }
}
