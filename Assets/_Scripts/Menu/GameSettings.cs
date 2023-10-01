using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private GameObject settingsWindow;

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    [SerializeField] private Toggle fullscreenToggle;

    private void Start()
    {
        //Loading PlayerPrefs
        masterSlider.value = PlayerPrefs.GetFloat("masterSave");
        musicSlider.value = PlayerPrefs.GetFloat("musicSave");
        soundSlider.value = PlayerPrefs.GetFloat("soundSave");
        fullscreenToggle.isOn = (PlayerPrefs.GetInt("fullscreen") != 0);
    }
    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }

    public void SetMasterVolume(float masterVolume)
    {
        audioMixer.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("masterSave", masterVolume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("musicSave", musicVolume);
    }

    public void SetSoundVolume(float soundVolume)
    {
        audioMixer.SetFloat("SoundVolume", soundVolume);
        PlayerPrefs.SetFloat("soundSave", soundVolume);
    }

    public void SetFullscreenMode(bool toggleValue)
    {
        Screen.fullScreen = toggleValue;
        PlayerPrefs.SetInt("fullscreen", (toggleValue ? 1 : 0));
    }


}
