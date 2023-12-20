using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{//AAAAAAAAAAAAAA
    //Opens another scene with the game
    public void StartGame()
    {
        SceneManager.LoadScene("Select Track");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    /*public void QuitToMain()
    {
        SceneManager.LoadScene("Main");
    }*/

    //Exits game
    public void ExitGame()
    {
        Application.Quit();
    }
}
