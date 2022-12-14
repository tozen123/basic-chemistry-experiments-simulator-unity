using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuickSettings : MonoBehaviour
{
    public PlayerInteractionController playerInteractionController;

    public GameObject startUp;
    public GameObject pausable;
    public bool isOn;
    public GameObject postProcessing;
    public GameObject Terrain;
    public GameObject effects;

    public GameObject howto;
    void Start()
    {
        startUp.SetActive(true);
        playerInteractionController.FreezeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if(isOn == false)
            {
                pausable.SetActive(true);
                playerInteractionController.FreezeGame();
            }

            if(isOn == true)
            {
                pausable.SetActive(false);
                playerInteractionController.unFreezeGame();
            }
        }

    }

    public void Continue()
    {
        if(howto.activeSelf == true)
        {
            howto.SetActive(false);
        }
        if (startUp.activeSelf == true)
        {
            startUp.SetActive(false);
        }
        
        if(pausable.activeSelf == true)
        {
            pausable.SetActive(false);
        }
        playerInteractionController.unFreezeGame();
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void lowerEffects(bool state)
    {
        effects.SetActive(state);
    }
    public void terrainG(bool state)
    {
        Terrain.SetActive(state);
    }
    public void PP(bool state)
    {
        postProcessing.SetActive(state);
    }
    public void how()
    {
        startUp.SetActive(false);
        howto.SetActive(true);
    }
}
