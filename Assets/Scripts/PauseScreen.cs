using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    //Main function of this script is that pauses the game and opens the pause menu
    public bool isGamePaused = false;

    public GameObject engine;
    public GameObject nitrous;
    public GameObject crash;

    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        if (CarController.disablePause == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isGamePaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;

        engine.SetActive(true);
        nitrous.SetActive(true);
        crash.SetActive(true);
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;

        engine.SetActive(false);
        nitrous.SetActive(false);
        crash.SetActive(false);
    }

    //Restarts the current track
    public void RestartGame()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        CarController.disablePause = true;


        if (TrackSelection.selectedTrack == 1)
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

    //Goes to the starting screen when the player clicks the button quit. It is used during the gameplay
    public void Quit()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        CarController.disablePause = true;
        SceneManager.LoadScene("Main");
    }
}
