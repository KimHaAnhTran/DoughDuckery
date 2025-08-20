using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject ribbonEssentialsUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void pauseGame()
    {
        pauseMenuUI.SetActive(true);
        ribbonEssentialsUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void resumeGame()
    {
        pauseMenuUI.SetActive(false);
        ribbonEssentialsUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

}
