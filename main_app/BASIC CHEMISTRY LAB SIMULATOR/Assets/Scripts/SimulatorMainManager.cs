using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulatorMainManager : MonoBehaviour
{
    public GameObject settingMenuCanvas;
    public GameObject settingSettingCanvas;

    private bool canOpen = true;

    public PlayerInteractionController _playerInteractionController;
    private void playWindowRender()
    {
        _playerInteractionController.unFreezeGame();
    }

    private void stopWindowRender()
    {
        _playerInteractionController.FreezeGame();
    }
    public void Resume()
    {
        Debug.Log("Closed");
        settingMenuCanvas.SetActive(false);
        playWindowRender();
        canOpen = true;
    }

    public void Settings()
    {
        settingSettingCanvas.SetActive(true);
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(canOpen)
            {
                Debug.Log("Opened");
                settingMenuCanvas.SetActive(true);
                stopWindowRender();
                canOpen = false;
            } else
            {
                Debug.Log("Closed");
                settingMenuCanvas.SetActive(false);
                playWindowRender();
                canOpen = true;
            }
        }
    }
}
