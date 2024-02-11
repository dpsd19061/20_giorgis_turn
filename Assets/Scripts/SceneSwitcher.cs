using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //Loads the track selection scene
    public void StartGame()
    {
        SceneManager.LoadScene("Select Track");
    }

    //Loads the controls scene
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    //Loads the credits scene
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    //Exits game
    public void ExitGame()
    {
        Application.Quit();
    }
}
