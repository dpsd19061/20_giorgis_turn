using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;

    void Update()
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

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void RestartGame()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;

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

    public void Quit()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        SceneManager.LoadScene("Main");
    }
}
