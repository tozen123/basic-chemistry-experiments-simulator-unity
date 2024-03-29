using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneSystem : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarFill;
    public float speed;

    public GameObject aboutus;
    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadSceneAsync(int sceneId)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / speed);
            LoadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }
    public void back()
    {
        aboutus.SetActive(false);
    }
    public void openabout()
    {
        aboutus.SetActive(true);
    }
}