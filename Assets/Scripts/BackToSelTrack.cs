using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSelTrack : MonoBehaviour
{
    public void BackToSelectTrack()
    {
        SceneManager.LoadScene("Select Track");
    }
}
