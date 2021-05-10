using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseMap : MonoBehaviour
{
    //Choose Map
    public Button map1;
    public Button map2;
    public Button map3;
    private int levelComplete;

    //Options Window
    public Slider[] voluneSlider;
    public Toggle[] resolutionToggles;
    public Toggle fullscreenToggle;
    public int[] screenWidths;
    int activeScreenResIndex;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("levelComplete");
        map1.interactable = true;
        map2.interactable = false;
        map3.interactable = false;

        switch (levelComplete)
        {
            case 1:
                map2.interactable = true;
                break;
            case 2:
                map2.interactable = true;
                map3.interactable = true;
                break;
        }

        activeScreenResIndex = PlayerPrefs.GetInt("screen res index");
        bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;

        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].isOn = i == activeScreenResIndex;
        }

        fullscreenToggle.isOn = isFullscreen;
    }
    public void LoadTo(string nameLevel)
    {
        SceneTransition.SwitchToScene(nameLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetScreenResolution(int i)
    {
        if (resolutionToggles[i].isOn)
        {
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
            PlayerPrefs.SetInt("screen res index", activeScreenResIndex);
            PlayerPrefs.Save();
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFullscreen;
        }

        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }

        PlayerPrefs.SetInt("fullscreen", ((isFullscreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float value){
        //AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
        
    }

    public void SetMenuVolume(float value){
        //AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }

}
