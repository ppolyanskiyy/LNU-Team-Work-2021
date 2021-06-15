using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseMap : MonoBehaviour
{
    public Button map1;
    public Button map2;
    private int levelComplete;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("levelComplete");
        map1.interactable = true;
        map2.interactable = true;

        switch (levelComplete)
        {
            case 1:
                map2.interactable = true;
                break;
        }
    }
    public void LoadTo(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
        //SceneTransition.SwitchToScene(nameLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
