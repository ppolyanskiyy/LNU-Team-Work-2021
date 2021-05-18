using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCheeps : MonoBehaviour
{
    private float cheeps = 0;
    [SerializeField] TextMeshProUGUI textCheeps;
    [SerializeField] MoveWall wall;

    private void Update()
    {
        if (cheeps == 2)
        {
            wall.Move();
        }
    }
    public void AmountCheeps()
    {
        cheeps++;
        textCheeps.text = cheeps.ToString();
    }
}
