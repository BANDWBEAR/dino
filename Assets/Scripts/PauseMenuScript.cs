using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isGamePaused = false;


    public void Pause() {
        if (isGamePaused)
        {
            Resume();
        }
        else {

            pauseMenu.SetActive(true);
            Time.timeScale = 0.05f;
            isGamePaused = true;
        }
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void Save() {

    }

    public void ExitToMenu() {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void Quit() {
        Application.Quit();
    }


}
