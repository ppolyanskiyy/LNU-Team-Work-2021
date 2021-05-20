using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public GameObject messageCanvas;
    public float Seconds = 3f;

    void Start()
    {
        StartCoroutine(ToDo());
    }

    IEnumerator ToDo()
    {
        yield return new WaitForSeconds(Seconds);
        messageCanvas.SetActive(false);
    }
}
