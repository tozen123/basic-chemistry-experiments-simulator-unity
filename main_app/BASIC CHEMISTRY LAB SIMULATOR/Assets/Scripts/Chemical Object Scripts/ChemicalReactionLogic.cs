using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalReactionLogic : MonoBehaviour
{
    public GameObject sparkParticle;
    public GameObject smokeParticle;
    public GameObject splashParticle;

    public float lifeTime = 5f; // 1 gram reaction time
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObjectBehaviourSystem>())
        {
            if (other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water")
            {
                Debug.Log("REACTED!");
                GameObject smokeParticleGO = Instantiate(smokeParticle, transform.position, Quaternion.identity);
                GameObject sparkParticleGO = Instantiate(sparkParticle, transform.position, Quaternion.identity);

                smokeParticleGO.transform.position = Vector3.MoveTowards(smokeParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
                sparkParticleGO.transform.position = Vector3.MoveTowards(sparkParticleGO.transform.position, transform.position, 6 * Time.deltaTime);

                Destroy(smokeParticleGO, lifeTime);
                Destroy(sparkParticleGO, lifeTime);

                Destroy(this.gameObject, lifeTime);
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<ObjectBehaviourSystem>())
        {
            if (other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water")
            {
                Debug.Log("REACTING!");

                
            }
        }
    }

}
