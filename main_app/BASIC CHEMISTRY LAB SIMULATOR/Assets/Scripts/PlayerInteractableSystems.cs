using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractableSystems : MonoBehaviour
{
    [SerializeField] private PlayerInteractionController _playerInteractionController;
    public GameObject _generatedSpawnTextEffect;
    public TextMeshProUGUI _generatedSpawnTextEffectText;
    public Transform releasePoint;
    public Vector3 _spawnOffset;

    void Start()
    {
        _playerInteractionController = GetComponent<PlayerInteractionController>();
        _generatedSpawnTextEffectText = _generatedSpawnTextEffect.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateLabEquipments(GameObject labEquipment)
    {
        GameObject obj = Instantiate(labEquipment, releasePoint.transform.position, Quaternion.identity);

        string labEquipmentTextName;
        labEquipmentTextName = labEquipment.GetComponent<ObjectBehaviourSystem>().objectId;
        spawnTextEffect(obj.transform.position, labEquipmentTextName);

        _playerInteractionController.unFreezeGame();
        _playerInteractionController._interactableSystemLabEquipmentsCabinetCanvas.SetActive(false);
    }

    public void spawnTextEffect(Vector3 pos, string name)
    {
        GameObject _genSpawnEffectText = Instantiate(_generatedSpawnTextEffect, pos, Quaternion.identity);
        _generatedSpawnTextEffectText.text = name;

        Destroy(_genSpawnEffectText, 1f);
    }
}
