using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform orientation;

    [Header("Movement")]
    [SerializeField] public float moveSpeed = 6f;
    float movementMultiplier = 10f;

    [Header("Drag")]
    [SerializeField] float groundDrag = 6f;

    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;
    Rigidbody rb;

    public AudioSource FoostepSource;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        MyInput();
        ControlDrag();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            FoostepSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            FoostepSource.Stop();
        }
    }
    void ControlDrag()
    {
        rb.drag = groundDrag;
    }
    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }
    
}
