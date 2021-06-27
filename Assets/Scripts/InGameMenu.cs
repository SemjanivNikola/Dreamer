using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject GeneralCanvas;
    public GameObject ControlCanvas;
    public AudioMixer AudioVolume;
    public Dropdown resDropdown;

    private bool isActive;
    Resolution[] resolutions;

    private void Start()
    {
        isActive = false;
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> options = new List<string>();

        int curResolution = 0, i = 0;

        foreach (Resolution r in resolutions)
        {
            string option = r.width + "x" + r.height;
            options.Add(option);

            if (r.width == Screen.currentResolution.width && r.height == Screen.currentResolution.height)
            {
                curResolution = i;
            }
            i++;
        }

        resDropdown.AddOptions(options);
        resDropdown.value = curResolution;
        resDropdown.RefreshShownValue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isActive)
            {
                OptionsMenu.SetActive(false);
                isActive = false;
            }
            else
            {
                OptionsMenu.SetActive(true);
                isActive = true;
            }
        }
    }

    public void OnOptionsClickX()
    {
        OptionsMenu.SetActive(false);
    }

    public void OnControlsClick()
    {
        ControlCanvas.SetActive(true);
        GeneralCanvas.SetActive(false);
    }
    public void OnGeneralClick()
    {
        ControlCanvas.SetActive(false);
        GeneralCanvas.SetActive(true);
    }

    public void SetVolume(float volume)
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

    public void SaveLevel(string sceneName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dreamland.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, sceneName);
        stream.Close();
    }
}
