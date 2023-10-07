using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject settingsWindow;

   public void PlayGame()
    {
        SceneManager.LoadScene("OpeningCutscene");
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
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScreen");
    }


}
