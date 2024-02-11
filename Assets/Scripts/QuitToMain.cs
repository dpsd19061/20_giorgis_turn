using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMain : MonoBehaviour
{
    //Goes to the starting screen when the player clicks the button quit. It is only for menu use
    public void QuitMain()
    {
        SceneManager.LoadScene("Main");
    }
}
