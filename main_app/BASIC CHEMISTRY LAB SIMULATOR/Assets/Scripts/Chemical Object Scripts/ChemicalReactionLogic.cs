using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalReactionLogic : MonoBehaviour
{
    public GameObject sparkParticle;
    public GameObject smokeParticle;
    public GameObject splashParticle;

    private float lifeTime = 2f; // 1 gram reaction time
    //TIME SETS
    //DEFAULT IS 2

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

    private void createFire(float fireSizing, float basedLifetime)
    {
        //special
        GameObject fireParticleGO = Instantiate(fireParticleLithium, transform.position, Quaternion.identity);
        fireParticleGO.transform.GetChild(0).gameObject.transform.localScale = new Vector3(fireSizing, fireSizing, fireSizing); // decrease Size

        fireParticleGO.transform.position = Vector3.MoveTowards(fireParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
        Destroy(fireParticleGO, lifeTime * basedLifetime);
    }

    private void createSmoke(float basedLifetime)
    {
        GameObject smokeParticleGO = Instantiate(smokeParticle, transform.position, Quaternion.identity);
        smokeParticleGO.transform.position = Vector3.MoveTowards(smokeParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
        Destroy(smokeParticleGO, lifeTime * basedLifetime);
    }

    private void createSparks(float basedLifetime)
    {
        GameObject sparkParticleGO = Instantiate(sparkParticle, transform.position, Quaternion.identity);
        sparkParticleGO.transform.position = Vector3.MoveTowards(sparkParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
        Destroy(sparkParticleGO, lifeTime * basedLifetime);

    }

    private void createExplosion(float baseSizing, float basedLifetime)
    {
        //special
        GameObject splashParticleGO = Instantiate(splashParticle, transform.position, Quaternion.identity);
        splashParticleGO.transform.GetChild(0).gameObject.transform.localScale = new Vector3(baseSizing, baseSizing, baseSizing); // decrease Size

        splashParticleGO.transform.position = Vector3.MoveTowards(splashParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
        Destroy(splashParticleGO, lifeTime * basedLifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObjectBehaviourSystem>())
        {
            // Adjustment Logical Overhaul
            // The Grams or weight must be affecting the result of the chemical reaction
            // must get the grams and apply to the effects created by kirby

            if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Lithium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // LITHIUM
            {
                Debug.Log("REACTED Lithium!");
                float chemicalWeight = this.gameObject.GetComponent<ObjectBehaviourSystem>().grams;

                Debug.Log("REACTED LITHIUM DATASETS | GRAMS: " + chemicalWeight);

                createSmoke(lifeTime * chemicalWeight);
                createFire(0.1f, lifeTime * chemicalWeight);
                Destroy(this.gameObject, lifeTime * chemicalWeight); // Multiplying the chemicalweight to the lifetime, so that if the weight is 1 the time range of the reaction will be multiplied to the default life time.

            }
            else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Sodium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // SODIUM
            {
                Debug.Log("REACTED Sodium!");
                float chemicalWeight = this.gameObject.GetComponent<ObjectBehaviourSystem>().grams;

                Debug.Log("REACTED SODIUM DATASETS | GRAMS: " + chemicalWeight);
                createSmoke(lifeTime * chemicalWeight);
                createSparks(lifeTime * chemicalWeight);
                Destroy(this.gameObject, lifeTime * chemicalWeight);  // Multiplying the chemicalweight to the lifetime, so that if the weight is 1 the time range of the reaction will be multiplied to the default life time.
            } else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Francium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // FRANCIUM
            {
                Debug.Log("REACTED Francium!");
                float chemicalWeight = this.gameObject.GetComponent<ObjectBehaviourSystem>().grams;

                Debug.Log("REACTED Francium DATASETS | GRAMS: " + chemicalWeight);
                createSmoke(lifeTime * chemicalWeight);
                createSparks(lifeTime * chemicalWeight);
                createFire(0.3f, lifeTime * chemicalWeight);

                Destroy(this.gameObject, lifeTime * chemicalWeight);  // Multiplying the chemicalweight to the lifetime, so that if the weight is 1 the time range of the reaction will be multiplied to the default life time.
            } else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Cesium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // Cesium
            {
                Debug.Log("REACTED Cesium!");
                float chemicalWeight = this.gameObject.GetComponent<ObjectBehaviourSystem>().grams;

                Debug.Log("REACTED Cesium DATASETS | GRAMS: " + chemicalWeight);
                createSmoke(lifeTime * chemicalWeight);


                Destroy(this.gameObject, lifeTime * chemicalWeight);  // Multiplying the chemicalweight to the lifetime, so that if the weight is 1 the time range of the reaction will be multiplied to the default life time.
            } else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Potassium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // Potassium
            {
                Debug.Log("REACTED Potassium!");
                float chemicalWeight = this.gameObject.GetComponent<ObjectBehaviourSystem>().grams;

                Debug.Log("REACTED Potassium DATASETS | GRAMS: " + chemicalWeight);
                createSmoke(lifeTime * chemicalWeight);


                Destroy(this.gameObject, lifeTime * chemicalWeight);  // Multiplying the chemicalweight to the lifetime, so that if the weight is 1 the time range of the reaction will be multiplied to the default life time.
            } else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Rubidium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // Rubidium
            {
                Debug.Log("REACTED Rubidium!");
                float chemicalWeight = this.gameObject.GetComponent<ObjectBehaviourSystem>().grams;

                Debug.Log("REACTED Rubidium DATASETS | GRAMS: " + chemicalWeight);
                createSmoke(lifeTime * chemicalWeight);


                Destroy(this.gameObject, lifeTime * chemicalWeight);  // Multiplying the chemicalweight to the lifetime, so that if the weight is 1 the time range of the reaction will be multiplied to the default life time.
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
