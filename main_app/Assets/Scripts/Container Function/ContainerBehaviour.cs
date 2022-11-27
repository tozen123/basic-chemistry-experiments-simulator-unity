using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehaviour : MonoBehaviour
{
    public Transform containingPlacement;

    [SerializeField] private GameObject[] containing;
    [SerializeField] private ObjectBehaviourSystem _objectBehaviourSystem;
    [SerializeField] private string dataNames = " ";
    public bool isContainingSomething;

    int i = 0;
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
            while (i < containingPlacement.childCount)
            {
                containing[i] = containingPlacement.GetChild(i).gameObject;
                dataNames += " " + containingPlacement.GetChild(i).gameObject.GetComponent<ObjectBehaviourSystem>().objectId;
                i++;
            }

            
            /*
            for (int i = 0; i < containingPlacement.childCount; i++)
            {
                if(i  > 2)
                {
                    break;
                } 
                containing[i] = containingPlacement.GetChild(i).gameObject;
                dataNames += " " + containingPlacement.GetChild(i).gameObject.GetComponent<ObjectBehaviourSystem>().objectId;
                Debug.Log(dataNames);
                Debug.Log(i);
            }
            */
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

                //dataNames += t.transform.gameObject.GetComponent<ObjectBehaviourSystem>().objectId;
            }
            */
            _objectBehaviourSystem.objectData = "Container with" + dataNames;
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
