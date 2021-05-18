using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChoose : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("MountainCastle");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
}
