using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalCabinetSystem : MonoBehaviour
{
    public GameObject sodiumPrefab;
    public GameObject potassiumPrefab;
    public GameObject caesiumPrefab;
    public GameObject rubidiumPrefab;
    public GameObject lithiumPrefab;
    public GameObject franciumPrefab;


    public Transform releasePoint;
    public PlayerInteractionController _playerInteractionController;

    public GramsController gramsController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void stopWindowRender()
    {
        _playerInteractionController.unFreezeGame();
        _playerInteractionController._interactableSystemChemicalCabinetCanvas.SetActive(false);
    }

    public void generateSodium()
    {
        GameObject chemicalComponent = Instantiate(sodiumPrefab, releasePoint.transform.position + new Vector3(0f, 0.8f, 0f), Quaternion.identity);
        chemicalComponent.GetComponent<ObjectBehaviourSystem>().grams = gramsController.GramsToAdd;
        stopWindowRender();
    }

    public void generatePotassium()
    {
        GameObject chemicalComponent = Instantiate(potassiumPrefab, releasePoint.transform.position + new Vector3(0f, 0.8f, 0f), Quaternion.identity);
        chemicalComponent.GetComponent<ObjectBehaviourSystem>().grams = gramsController.GramsToAdd;
        stopWindowRender();
    }
    public void generateCaesium()
    {
        GameObject chemicalComponent = Instantiate(caesiumPrefab, releasePoint.transform.position + new Vector3(0f, 0.8f, 0f), Quaternion.identity);
        chemicalComponent.GetComponent<ObjectBehaviourSystem>().grams = gramsController.GramsToAdd;
        stopWindowRender();
    }
    public void generateRubidium()
    {
        GameObject chemicalComponent = Instantiate(rubidiumPrefab, releasePoint.transform.position + new Vector3(0f, 0.8f, 0f), Quaternion.identity);
        chemicalComponent.GetComponent<ObjectBehaviourSystem>().grams = gramsController.GramsToAdd;
        stopWindowRender();
    }
    public void generateLithium()
    {
        GameObject chemicalComponent = Instantiate(lithiumPrefab, releasePoint.transform.position + new Vector3(0f, 0.8f, 0f), Quaternion.identity);
        chemicalComponent.GetComponent<ObjectBehaviourSystem>().grams = gramsController.GramsToAdd;
        stopWindowRender();
    }
    public void generateFrancium()
    {
        GameObject chemicalComponent = Instantiate(franciumPrefab, releasePoint.transform.position + new Vector3(0f, 0.8f, 0f), Quaternion.identity);
        chemicalComponent.GetComponent<ObjectBehaviourSystem>().grams = gramsController.GramsToAdd;
        stopWindowRender();
    }
}
