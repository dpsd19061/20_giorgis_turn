using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSelTrack : MonoBehaviour
{
    //For a back button that goes from the car selection page to track selection
    public void BackToSelectTrack()
    {
        SceneManager.LoadScene("Select Track");
    }
}
