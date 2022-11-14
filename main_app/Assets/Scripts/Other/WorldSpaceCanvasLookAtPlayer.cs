using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceCanvasLookAtPlayer : MonoBehaviour
{
    public Camera _camera;
    public Vector3 _offset;
    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position + _offset);
    }
}
