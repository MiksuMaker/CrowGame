using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject settingsWindow;

   public void PlayGame()
    {
        SceneManager.LoadScene("LevelBlockout");
    }

    public void SettingButton()
    {
        settingsWindow.SetActive(true);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }


}
