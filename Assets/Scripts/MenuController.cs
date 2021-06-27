using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public AudioMixer AudioVolume;
    public Dropdown resDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> options = new List<string>();

        int curResolution = 0, i = 0;

        foreach (Resolution r in resolutions)
        {
            string option = r.width + "x" + r.height;
            options.Add(option);

            if(r.width == Screen.currentResolution.width && r.height == Screen.currentResolution.height)
            {
                curResolution = i;
            }
            i++;
        }

        resDropdown.AddOptions(options);
        resDropdown.value = curResolution;
        resDropdown.RefreshShownValue();
    }

    public void OnOptionsClickX()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OnMenuClickOptions()
    {
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void SetVolume (float volume)
    {
        AudioVolume.SetFloat("MainVolume", volume);
    }
    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
