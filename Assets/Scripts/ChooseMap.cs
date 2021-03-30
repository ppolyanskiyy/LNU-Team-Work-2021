using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseMap : MonoBehaviour
{
    public Button map1;
    public Button map2;
    public Button map3;
    private int levelComplete;


    // Start is called before the first frame update
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
    }
    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

}
