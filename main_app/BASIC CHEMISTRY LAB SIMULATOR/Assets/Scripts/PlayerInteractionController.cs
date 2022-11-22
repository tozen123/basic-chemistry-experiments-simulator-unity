using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteractionController : MonoBehaviour
{
    [Header("Player Sight")]
    public GameObject sighted;
    public string sighted_objectID;

    public PlayerCameraController _playerCameraController;

    [Header("Player Hand")]
    public GameObject onHoldObject;
    public Transform holdPosReference;

    public GameObject objGhost;

    [Header("Player Sight Attributes")]
    public float viewRange;

    [Header("UI References")]
    public GameObject pickUpCanvas;
    public TextMeshProUGUI pickUpCanvastext;
    public TextMeshProUGUI objectNameText;
    public TextMeshProUGUI objectDataText;

    public GameObject canvasWarning;
    public TextMeshProUGUI canvasWarningText;

    [Header("References")]
    public PlayerAnimationControl _playerAnimControl;

    public Camera _camera;
    public GameObject holdingUICanvas;

    public GameObject interactableSystemCanvas;
    public TextMeshProUGUI _interactableSystemUIText;

    public Vector3 obj_LastPosition;

    public Vector3 sightedVector;

    [Header("InteractableSystem UI Chemical Cabinet Reference")]
    public GameObject _interactableSystemChemicalCabinetCanvas;

    [Header("InteractableSystem UI Lab Equipments Cabinet Reference")]
    public GameObject _interactableSystemLabEquipmentsCabinetCanvas;

    [Header("InteractableSystem UI Sink Table Reference")]
    public GameObject _interactableSystemSinkTableCanvas;
    // ---------------------------------------------------------------------------------------------------------------------------//
    // ---------------------------------------------------------------------------------------------------------------------------//
    //
    // Make Right Click Cancel Anywhere 
    // Change Transparent Color to Red or The Ghost will disappear if the user hover to wrong place
    // if they press place button in wrong position a prompt will appear and cancel the placement activity
    //
    // ---------------------------------------------------------------------------------------------------------------------------//
    // ---------------------------------------------------------------------------------------------------------------------------//

    private void Start()
    {
        _interactableSystemChemicalCabinetCanvas.SetActive(false);
        _interactableSystemLabEquipmentsCabinetCanvas.SetActive(false);
        _interactableSystemSinkTableCanvas.SetActive(false);

        interactableSystemCanvas.SetActive(false);
        holdingUICanvas.SetActive(false);
        pickUpCanvas.SetActive(false);
        canvasWarningText = canvasWarning.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Sight();
        obj_LastPosition = transform.position + new Vector3(0f, 0.2f, 0f);
    }

    private void ObjectPickedUp()
    {
        holdingUICanvas.SetActive(true);

        sighted.GetComponent<Rigidbody>().isKinematic = true;
        sighted.GetComponent<BoxCollider>().enabled = false;

        onHoldObject = sighted.gameObject;
        
        objGhost = Instantiate(onHoldObject, holdPosReference.transform.position, Quaternion.identity);
        objGhost.gameObject.GetComponent<ObjectBehaviourSystem>()._disableGhostMode();
        objGhost.transform.parent = holdPosReference.transform;
        objGhost.transform.position = holdPosReference.transform.position;

        if (sighted.GetComponent<ObjectBehaviourSystem>().objectId == "Container" || sighted.GetComponent<ObjectBehaviourSystem>().objectId == "Beaker")
        {
            foreach (Transform t in sighted.transform.GetChild(1).GetComponentsInChildren<Transform>())
            {
                
                if (t.transform.GetComponent<BoxCollider>())
                {
                    t.transform.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }

        disablePickUpCanvas();
       
    }

    private void Sight()
    {
        RaycastHit hit;
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, viewRange))
        {
            sightedVector = hit.transform.position;
            if (hit.transform.gameObject.GetComponent<ObjectBehaviourSystem>())
            {
                sighted = hit.transform.gameObject;

                if (onHoldObject == null) // if walang kapit yung player
                {
                    pickUpCanvastext.text = "Press F to Pick Up";

                    if (sighted.GetComponent<ObjectBehaviourSystem>())
                    {
                        sighted_objectID = sighted.GetComponent<ObjectBehaviourSystem>().objectId;
                    }

                    sighted.gameObject.GetComponent<Outline>().enabled = true;

                    canvasWarningText.text = "INTERACTION_ERROR_2: You can not pick up chemical with barehands! Please get beakers on the cabinet.";
                    if (Input.GetKeyDown("f"))
                    {
                        _playerAnimControl.holdingAnimation();

                        if (!sighted.gameObject.GetComponent<ObjectBehaviourSystem>().isChemical)
                        {
                            sighted.gameObject.GetComponent<Outline>().enabled = false;
                            sighted.GetComponent<ObjectBehaviourSystem>()._enableGhostMode();
                            ObjectPickedUp();
                            Debug.Log("1");

                            if (sighted.transform.GetChild(0))
                            {
                                if (sighted.transform.GetChild(0).childCount > 0)
                                {
                                    sighted.transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
                                    sighted.transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>().useGravity = false;
                                    sighted.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = false;
                                }
                            }


                        }
                        else
                        {
                            // instantiate warning that you cant pick up chemical barehands, you need container
                            GameObject _warningCanvas = Instantiate(canvasWarning, hit.transform.position, Quaternion.identity);
                            canvasWarningText.text = "INTERACTION_ERROR_2: You can not pick up chemical with barehands! Please get beakers on the cabinet.";
                            Destroy(_warningCanvas, 1.5f);
                        }
                    }
                } else // if may kapit ung player
                {
                    // if yung kapit is container
                    if (onHoldObject.GetComponent<ObjectBehaviourSystem>().objectId == "Container" || onHoldObject.GetComponent<ObjectBehaviourSystem>().objectId == "Beaker")
                    {
                        
                        pickUpCanvastext.text = "Press F to Put it on the " + onHoldObject.GetComponent<ObjectBehaviourSystem>().objectId;
                        // dapat ang action ay kaya mag pick up at mag pour 
                        // pag priness f

                        //pick up function
                        canvasWarningText.text = "INTERACTION_ERROR_3: You can not pick up container with container";
                        if (Input.GetKeyDown("f"))
                        {
                            // check if ung container is may laman
                            if (!onHoldObject.GetComponent<ContainerBehaviour>().isContainingSomething) // if walang laman ung kapit
                            {
                                if(sighted.GetComponent<ObjectBehaviourSystem>().objectId == "Container" || sighted.GetComponent<ObjectBehaviourSystem>().objectId == "Beaker")
                                {
                                    GameObject _warningCanvas = Instantiate(canvasWarning, hit.transform.position, Quaternion.identity);
                                    canvasWarningText.text = "INTERACTION_ERROR_3: You can not pick up container with container";
                                    Destroy(_warningCanvas, 1.5f);

                                    return;
                                } else
                                {
                                    // if pag walang laman ung container pwede sya mag pick up ng mga chemicals

                                    sighted = hit.transform.gameObject;
                                    sighted.gameObject.GetComponent<Outline>().enabled = true;

                                    sighted.GetComponent<Rigidbody>().isKinematic = true;
                                    sighted.GetComponent<BoxCollider>().enabled = false;
                                    sighted.GetComponent<Rigidbody>().useGravity = false;

                                    //add randomizer
                                    float rander = Random.Range(-0.1f, 0.1f);

                                    //Debug.Log(onHoldObject.transform.GetChild(0).transform.position + new Vector3(rander, 0f, rander));
                                    sighted.transform.position = onHoldObject.transform.GetChild(0).transform.position + new Vector3(rander, 0f, rander);
                                    sighted.transform.parent = onHoldObject.transform.GetChild(0);


                                }
                                
                                Debug.Log("2");
                            }
                            else 
                            {
                                canvasWarningText.text = "INTERACTION_ERROR_4: You can not pick up chemical with container full! ";
                                if (onHoldObject.GetComponent<ContainerBehaviour>().isContainingSomething)
                                {
                                    if(sighted.GetComponent<ObjectBehaviourSystem>().objectId == "Container" || sighted.GetComponent<ObjectBehaviourSystem>().objectId == "Beaker")
                                    {
                                        if (sighted.GetComponent<ContainerBehaviour>().isContainingSomething)
                                        {
                                            // pouring one container to another

                                            Debug.Log("3");
                                            Debug.Log(onHoldObject.transform.GetChild(0).GetChild(0).transform.gameObject);
                                            Debug.Log(sighted.transform.GetChild(0).transform.gameObject);

                                            // add randomization 
                                            float rander = Random.Range(-0.1f, 0.1f);

                                            onHoldObject.transform.GetChild(0).GetChild(0).transform.position = sighted.transform.GetChild(0).transform.position + new Vector3(rander, 0f, rander);
                                            onHoldObject.transform.GetChild(0).GetChild(0).transform.parent = sighted.transform.GetChild(0).transform;
                                            

                                            // create function where we can mix two container 

                                        }
                                    }
                                    else
                                    {
                                        // instantiate warning that you cant pick up chemical with full container
                                        GameObject _warningCanvas = Instantiate(canvasWarning, hit.transform.position, Quaternion.identity);
                                        canvasWarningText.text = "INTERACTION_ERROR_4: You can not pick up chemical with container full! ";
                                        Destroy(_warningCanvas, 1.5f);
                                    }
                                } 
                                
                            }
                        }

                        // TEST CODE MIGHT BE REMOVED
                        if (Input.GetKeyDown("g"))
                        {
                            Debug.Log("3: Pour Function or Contain Transfer");
                        }
                    }
                }
 
                enablePickUpCanvas();
                objectNameText.text = hit.transform.gameObject.GetComponent<ObjectBehaviourSystem>().objectId;
                objectDataText.text = hit.transform.gameObject.GetComponent<ObjectBehaviourSystem>().objectData;
                pickUpCanvas.transform.position = hit.transform.position;
                
            } 
            else
            {
                if(sighted != null)
                {
                    sighted.gameObject.GetComponent<Outline>().enabled = false;
                }

                disablePickUpCanvas();
                sighted = null;
                sighted_objectID = "";
            }

            if (onHoldObject != null)
            {
                if (hit.transform.gameObject.layer == 6)
                {
                    ObjectPlacement(onHoldObject);
                }
            }

            // If the raycast hit detected a Interatable System (Sink, Cabinet)
            if(hit.transform.gameObject.layer == 8)
            {
                InteractableSystem(hit.transform.gameObject);
                interactableSystemCanvas.transform.position = hit.transform.position;
            } 
        } 
        else
        {
            interactableSystemCanvas.SetActive(false);
        }
    }

    private void ObjectPlacement(GameObject _object)
    {
        RaycastHit hit;
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit, viewRange))
        {
            _object.GetComponent<ObjectBehaviourSystem>()._enableGhostMode();
            
            if (hit.transform.gameObject.layer == 6)
            {
                Vector3 placementPosition = new Vector3(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y), Mathf.RoundToInt(hit.point.z));
                _object.transform.position = placementPosition;

                if (Input.GetKeyDown("f") || Input.GetMouseButtonDown(0))
                {
                    //Debug.Log("OBJECT PLACED");
                    _playerAnimControl.notHoldingAnimation();

                    _object.transform.position = placementPosition;

                    onHoldObject = null;
                    _object.GetComponent<Rigidbody>().isKinematic = false;
                    _object.GetComponent<BoxCollider>().enabled = true;


                    // UPDATE THIS PART!!
                    // UPDATE THIS PART!!
                    // UPDATE THIS PART!!
                    // UPDATE THIS PART!!
                    // UPDATE THIS PART!!
                    // UPDATE THIS PART!!
                    //
                    // To fix the Bug where the pre placement object offset create logic due to the trigger collision! 
                    //_object.GetComponent<BoxCollider>().isTrigger = true;
                    //
                    //
                    // UPDATE THIS PART!!
                    // UPDATE THIS PART!!
                    // UPDATE THIS PART!!
                    // UPDATE THIS PART!!
                    // UPDATE THIS PART!!
                    // UPDATE THIS PART!!

                    _object.GetComponent<ObjectBehaviourSystem>()._disableGhostMode();

                    holdingUICanvas.SetActive(false);
                    Destroy(objGhost);
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            //Debug.Log("OBJECT PLACEMENT CANCELLED");
            _object.transform.position = obj_LastPosition;

            onHoldObject = null;
            _object.GetComponent<Rigidbody>().isKinematic = false;
            _object.GetComponent<BoxCollider>().enabled = true;

            _object.GetComponent<ObjectBehaviourSystem>()._disableGhostMode();

            holdingUICanvas.SetActive(false);
            Destroy(objGhost);
        }
    }

    private void enablePickUpCanvas()
    {
        pickUpCanvas.SetActive(true);
    }

    private void disablePickUpCanvas()
    {
        pickUpCanvas.SetActive(false);
    }

    void InteractableSystem(GameObject _interactableSystem)
    {
        //Container and Sink Interaction
        if(onHoldObject != null)
        {
            //Mag aactivate lang ang container and sink interaction if may kapit na container ung player
            if (onHoldObject.GetComponent<ObjectBehaviourSystem>().objectId == "Container" || onHoldObject.GetComponent<ObjectBehaviourSystem>().objectId == "Beaker")
            {
                if (_interactableSystem.GetComponent<InteractableSystemBehaviour>().interactableSystemID == "Sink")
                {
                    ChangeUIText(_interactableSystemUIText, "Sink");
                    interactableSystemCanvas.SetActive(true);

                    Debug.Log("Sink Success F");
                    InteractSinkTable(_interactableSystem);
                }
            }
        } 
        else 
        {
            // ELSE pag null or walang kapit yung player na object, pwede sya mag interact sa cabinet at sink 
            // pero sa sink wala sya mag interact mag lalabas lang yung canvas
            //General

            if (_interactableSystem.GetComponent<InteractableSystemBehaviour>().interactableSystemID == "Chemical Cabinet")
            {
                ChangeUIText(_interactableSystemUIText, "Chemical Cabinet");
                interactableSystemCanvas.SetActive(true);

                Debug.Log("Cabinet");
                InteractChemicalCabinet();

            } else if (_interactableSystem.GetComponent<InteractableSystemBehaviour>().interactableSystemID == "Lab Equipments Shelves")
            {
                ChangeUIText(_interactableSystemUIText, "Lab Equipments Shelves");

                interactableSystemCanvas.SetActive(true);


                Debug.Log("Cabinet");
                InteractLabEquipmentsCabinet();

            } else if (_interactableSystem.GetComponent<InteractableSystemBehaviour>().interactableSystemID == "Sink")
            {
                // if nag interact yung player ng wala syang container sa hands nuiya mag eerror or warning sa player 
                
                if (Input.GetKeyDown("f"))
                {
                    GameObject _warningCanvas = Instantiate(canvasWarning, sightedVector, Quaternion.identity);
                    canvasWarningText.text = "You can't interact with the Sink unless you have an object in yours hands.";
                    Destroy(_warningCanvas, 1.5f);
                }

                ChangeUIText(_interactableSystemUIText, "Sink");
                interactableSystemCanvas.SetActive(true);
                Debug.Log("Sink Failed ");
            }
        }
    }

    public void ChangeUIText(TextMeshProUGUI _text, string _newtext)
    {
        _text.text = _newtext.ToString();
    }

    private bool isGameFreeze = false;
    public void InteractChemicalCabinet()
    {
        if (Input.GetKeyDown("f"))
        {
            if (isGameFreeze)
            {
                unFreezeGame();
                _interactableSystemChemicalCabinetCanvas.SetActive(false);
            }
            else
            {
                FreezeGame();
                _interactableSystemChemicalCabinetCanvas.SetActive(true);
            }
        }
    }

    public void InteractLabEquipmentsCabinet()
    {
        if (Input.GetKeyDown("f"))
        {
            if (isGameFreeze)
            {
                unFreezeGame();
                _interactableSystemLabEquipmentsCabinetCanvas.SetActive(false);
            }
            else
            {
                FreezeGame();
                _interactableSystemLabEquipmentsCabinetCanvas.SetActive(true);
            }
        }
    }

    public void InteractSinkTable(GameObject _interactableSystem)
    {
        Debug.Log("CONTAINER: " + onHoldObject.transform.GetChild(0).childCount);

        if(onHoldObject.transform.GetChild(0).childCount == 0 )
        {
            if (Input.GetKeyDown("f"))
            {
                if (isGameFreeze)
                {
                    unFreezeGame();
                    _interactableSystemSinkTableCanvas.SetActive(false);
                    if (_interactableSystem.GetComponent<SinkSystem>())
                    {
                        _interactableSystem.GetComponent<SinkSystem>().ContainerInTheSink = null;

                    }
                }
                else
                {
                    FreezeGame();
                    _interactableSystemSinkTableCanvas.SetActive(true);
                    if (_interactableSystem.GetComponent<SinkSystem>())
                    {
                        _interactableSystem.GetComponent<SinkSystem>().ContainerInTheSink = onHoldObject.gameObject;

                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown("f"))
            {
                GameObject _warningCanvas = Instantiate(canvasWarning, sightedVector, Quaternion.identity);
                canvasWarningText.text = "You can't interact with the Sink with container full!";
                Destroy(_warningCanvas, 1.5f);
            }
        }
    }

    public void FreezeGame()
    {
        Time.timeScale = 0;
        isGameFreeze = true;
        _playerCameraController.isGameFreeze = true;
    }

    public void unFreezeGame()
    {
        Time.timeScale = 1;
        isGameFreeze = false;
        _playerCameraController.isGameFreeze = false;
    }
}
