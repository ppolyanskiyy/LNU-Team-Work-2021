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
    [SerializeField] string nameScene;


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MountainCastle")
        {
            if (cheeps == 2)
            {
                wall.Move();
            }
        }
        if(cheeps == 3)
        {
            SceneManager.LoadScene(nameScene);
        }
    }
    public void AmountCheeps()
    {
        cheeps++;
        textCheeps.text = cheeps.ToString();
    }
}
