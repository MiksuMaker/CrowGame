using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isGamePaused;

    [SerializeField] private GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (isGamePaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isGamePaused = false;  
            }
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isGamePaused = true;
            }
        }
    }

    public void ContinueGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
