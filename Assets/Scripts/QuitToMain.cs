using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMain : MonoBehaviour
{

    public void QuitMain()
    {
        SceneManager.LoadScene("Main");
    }
}
