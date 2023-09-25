using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject settingsMenu;
    public GameObject mainMenu;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void LeaveButton()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
