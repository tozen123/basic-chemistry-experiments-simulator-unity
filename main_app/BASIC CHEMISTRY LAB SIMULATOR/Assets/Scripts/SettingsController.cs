using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public PlayerCameraController _playerCameraController;
    public PlayerController _playerController;

    public Slider mouseSensitivity;
    public Slider movementSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerCameraController.sensX = float.Parse(mouseSensitivity.value.ToString("0.0"));
        _playerCameraController.sensY = float.Parse(mouseSensitivity.value.ToString("0.0"));

        _playerController.moveSpeed = float.Parse(movementSpeed.value.ToString("0.0"));
    }

}
