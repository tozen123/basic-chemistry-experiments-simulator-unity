using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehaviour : MonoBehaviour
{
    public Transform containingPlacement;

    //[SerializeField] private GameObject[] containing;
    [SerializeField] private List<GameObject> containing = new List<GameObject>();
    [SerializeField] private ObjectBehaviourSystem _objectBehaviourSystem;
    [SerializeField] private string dataNames = " ";
    public bool isContainingSomething;

    // Main Attributes
    public float maximumLiters = 5f;
    void Start()
    {
        
    }
    /*
     * fix the looping error
     * 
     */
    void Update()
    {
        CheckContainer(); // Check if this container has something

        if (containingPlacement.childCount > 0)
        {
            isContainingSomething = true;
            for (int i = 0; i < containingPlacement.childCount; i++)
            {
                //containing[i] = containingPlacement.GetChild(i).gameObject;
                //dataNames += " " + containingPlacement.GetChild(i).gameObject.GetComponent<ObjectBehaviourSystem>().objectId;
                
                //Debug.Log(containingPlacement.GetChild(i).gameObject);
                //Debug.Log(i);
            }
        }
        else
        {
            containing = null;
        }


        if (isContainingSomething)
        {
            /*
            foreach (Transform t in containingPlacement.GetComponentsInChildren<Transform>()[0])
            {
                Debug.Log("test: "+t.name);

                dataNames = t.transform.gameObject.GetComponent<ObjectBehaviourSystem>().objectId;
            }
             _objectBehaviourSystem.objectData = "Container with" + dataNames;
            */
            if (containingPlacement.childCount == 1)
            {
                _objectBehaviourSystem.objectData = "Container with " + containingPlacement.GetChild(0).gameObject.GetComponent<ObjectBehaviourSystem>().objectId;
            } else if (containingPlacement.childCount == 2)
            {
                _objectBehaviourSystem.objectData = "Container with " + containingPlacement.GetChild(0).gameObject.GetComponent<ObjectBehaviourSystem>().objectId + " And " + containingPlacement.GetChild(1).gameObject.GetComponent<ObjectBehaviourSystem>().objectId;
            }
           
        }
        else
        {
            _objectBehaviourSystem.objectData = "Empty";
        }
    }

    private void CheckContainer()
    {
        if (containing == null)
        {
            isContainingSomething = false;
        }
        else if (containing != null)
        {
            isContainingSomething = true;
        }
    }

    // put something in the container
    public void Put()
    {

    }
    // remove something in the container
    public void RemoveContaining()
    {


    }
}
