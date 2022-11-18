using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SinkSystem : MonoBehaviour
{
    public TextMeshProUGUI measurementText;
    public Image measurementImageFG;

    public float waterfill_liters;
    public float sink_fill_intensity;

    public GameObject ContainerInTheSink;
    public GameObject waterPrefab;

    public PlayerInteractionController _playerInteractionController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waterfill_liters < 0)
        {
            waterfill_liters = 0;
        }

        measurementText.text = "Liters: " + waterfill_liters.ToString();
        if(ContainerInTheSink != null)
        {
            measurementImageFG.fillAmount = waterfill_liters / ContainerInTheSink.GetComponent<ContainerBehaviour>().maximumLiters;
        }
       
    }

    public void fillSink()
    {
        waterfill_liters += sink_fill_intensity;
    }

    public void reduceSink()
    {
        waterfill_liters -= sink_fill_intensity;
    }

    public void doneSink()
    {
        GameObject water = Instantiate(waterPrefab, transform.position + new Vector3(0f, 0.8f, 0f), Quaternion.identity);
        water.GetComponent<WaterBehaviourSystem>().waterVolume = waterfill_liters;

        stopWindowRender();
        resetData();
        //reset data
    }

    public void cancelSink()
    {
        //reset data
        stopWindowRender();
        resetData();
    }

    private void stopWindowRender()
    {
        _playerInteractionController.unFreezeGame();
        _playerInteractionController._interactableSystemSinkTableCanvas.SetActive(false);
    }
    private void resetData()
    {
        waterfill_liters = 0;
    }
}
