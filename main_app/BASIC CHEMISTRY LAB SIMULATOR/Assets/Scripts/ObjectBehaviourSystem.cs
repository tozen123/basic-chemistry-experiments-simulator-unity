using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviourSystem : MonoBehaviour
{

    [SerializeField] private Renderer _model;
    [SerializeField] private Color _offColor;

    public bool isChemical;
    public bool isUsableObject;

    public string objectId;
    public string objectData;

    private void Start()
    {
        _offColor = _model.material.color;
    }

    private void Update()
    {
        if (this.GetComponent<WaterBehaviourSystem>())
        {
            objectData = "Water - " + this.GetComponent<WaterBehaviourSystem>().waterVolume + "Liter(s)";
        }
    }
    public void _enableGhostMode()
    {
        Color color = _model.material.color;
        color.a = 0.5f;
        _model.material.color = color;
    }

    public void _disableGhostMode()
    {
        _model.material.color = _offColor;
    }

}
