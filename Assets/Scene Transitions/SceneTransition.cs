using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SceneTransition : MonoBehaviour
{
    public Text loadingPercents;

    private Animator componentAnimator;
    private static SceneTransition instance;
    private AsyncOperation loadingSceneOperation;
    private static bool shouldPlayOpeningAnimation = false;

    public static void SwitchToScene(string nameLevel)
    {

        instance.componentAnimator.SetTrigger(name: "sceneClosing");
        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(nameLevel);
        instance.loadingSceneOperation.allowSceneActivation = false;
    }

    private void Start()
    {
        instance = this;
        componentAnimator = GetComponent<Animator>();
        if (shouldPlayOpeningAnimation)
        {
            componentAnimator.SetTrigger("sceneOpening");
            shouldPlayOpeningAnimation = false;
        }
    }

    void Update()
    {
        if (loadingSceneOperation != null)
        {
            loadingPercents.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";
        }
    }

    public void OnAnimationOver()
    {
        shouldPlayOpeningAnimation = true;
        loadingSceneOperation.allowSceneActivation = true;
    }
}
