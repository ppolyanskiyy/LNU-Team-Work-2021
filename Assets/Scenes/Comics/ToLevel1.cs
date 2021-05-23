using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel1 : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] string nameScene;
    void Start()
    {
        Invoke("ToDo", time);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(nameScene);
        }
    }
    public void ToDo()
    {
        SceneManager.LoadScene(nameScene);
    }

}
