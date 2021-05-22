using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCheeps : MonoBehaviour
{
    private float cheeps = 0;
    [SerializeField] TextMeshProUGUI textCheeps;
    [SerializeField] MoveWall wall;


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MountainCastle")
        {
            if (cheeps == 2)
            {
                wall.Move();
            }
        }
        //else if (SceneManager.GetActiveScene().name == "Level2")
        //{

        //}
    }
    public void AmountCheeps()
    {
        cheeps++;
        textCheeps.text = cheeps.ToString();
    }
}
