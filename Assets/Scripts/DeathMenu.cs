using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenu;
    public PlayerController player;
    

    public void Reload()
    {
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Global.GroundMovementSpeed = 5f;
    }

    public void ExitToMenu()
    {
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Global.GroundMovementSpeed = 5f;
    }
}
