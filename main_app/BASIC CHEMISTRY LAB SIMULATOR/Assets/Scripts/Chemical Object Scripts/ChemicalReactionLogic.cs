using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalReactionLogic : MonoBehaviour
{
    public GameObject sparkParticle;
    public GameObject smokeParticle;
    public GameObject splashParticle;

    public float lifeTime = 2f; // 1 gram reaction time
    public GameObject fireParticleLithium;

    public GameObject sparkParticleFrancium;
    public GameObject smokeParticleFrancium;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // size determinator


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObjectBehaviourSystem>())
        {
            if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Lithium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // LITHIUM
            {
                Debug.Log("REACTED Lithium!");
                GameObject smokeParticleGO = Instantiate(smokeParticle, transform.position, Quaternion.identity);
                GameObject fireParticleGO = Instantiate(fireParticleLithium, transform.position, Quaternion.identity);
                fireParticleGO.transform.GetChild(0).gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                smokeParticleGO.transform.position = Vector3.MoveTowards(smokeParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
                fireParticleGO.transform.position = Vector3.MoveTowards(fireParticleGO.transform.position, transform.position, 6 * Time.deltaTime);

                Destroy(smokeParticleGO, lifeTime);
                Destroy(fireParticleGO, lifeTime);

                Destroy(this.gameObject, lifeTime);

            }else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Sodium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // SODIUM
            {
                Debug.Log("REACTED Sodium!");
                GameObject smokeParticleGO = Instantiate(smokeParticle, transform.position, Quaternion.identity);
                GameObject sparkParticleGO = Instantiate(sparkParticle, transform.position, Quaternion.identity);

                //var sz = smokeParticleGO.transform.GetChild(0).GetComponent<ParticleSystem>().main.startSize;
                //sz = new ParticleSystem.MinMaxCurve(0.5f, 2f);

                smokeParticleGO.transform.position = Vector3.MoveTowards(smokeParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
                sparkParticleGO.transform.position = Vector3.MoveTowards(sparkParticleGO.transform.position, transform.position, 6 * Time.deltaTime);

                Destroy(smokeParticleGO, lifeTime);
                Destroy(sparkParticleGO, lifeTime);

                Destroy(this.gameObject, lifeTime);
            } else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Francium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // FRANCIUM
            {
                Debug.Log("REACTED Francium!");
                GameObject smokeParticleGO = Instantiate(smokeParticle, transform.position, Quaternion.identity);
                GameObject sparkParticleGO = Instantiate(sparkParticle, transform.position, Quaternion.identity);

                //var sz = smokeParticleGO.transform.GetChild(0).GetComponent<ParticleSystem>().main.startSize;
                //sz = new ParticleSystem.MinMaxCurve(0.5f, 2f);

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
            if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Sodium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water")
            {
                //Debug.Log("Sodium!");
                float randomPos = Random.Range(-0.01f, 0.01f);
                this.transform.position = transform.position + new Vector3(randomPos, 0f, randomPos);

            } else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Francium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water")
            {
                //Debug.Log("Francium!");
                float randomPos = Random.Range(-0.01f, 0.01f);
                this.transform.position = transform.position + new Vector3(randomPos, 0f, randomPos);

            }
        }
    }

}
