using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;
    Camera cam;
    public Camera otherCamera;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    public bool isGameFreeze = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        if (Input.GetMouseButtonDown(1))
        {
            cam.fieldOfView = 40f;
            otherCamera.fieldOfView = 40f;
        }
        if (Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = 80f;
            otherCamera.fieldOfView = 80f;
        }

        if (!isGameFreeze)
        {
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        
    }
    private void PlayerInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
