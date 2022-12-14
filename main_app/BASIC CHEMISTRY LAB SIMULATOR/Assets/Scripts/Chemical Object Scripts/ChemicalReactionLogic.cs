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

    private void createFire(float fireSizing)
    {
        //special
        GameObject fireParticleGO = Instantiate(fireParticleLithium, transform.position, Quaternion.identity);
        fireParticleGO.transform.GetChild(0).gameObject.transform.localScale = new Vector3(fireSizing, fireSizing, fireSizing); // decrease Size

        fireParticleGO.transform.position = Vector3.MoveTowards(fireParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
        Destroy(fireParticleGO, lifeTime);
    }

    private void createSmoke()
    {
        GameObject smokeParticleGO = Instantiate(smokeParticle, transform.position, Quaternion.identity);
        smokeParticleGO.transform.position = Vector3.MoveTowards(smokeParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
        Destroy(smokeParticleGO, lifeTime);
    }

    private void createSparks()
    {
        GameObject sparkParticleGO = Instantiate(sparkParticle, transform.position, Quaternion.identity);
        sparkParticleGO.transform.position = Vector3.MoveTowards(sparkParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
        Destroy(sparkParticleGO, lifeTime);

    }

    private void createExplosion(float baseSizing)
    {
        //special
        GameObject splashParticleGO = Instantiate(splashParticle, transform.position, Quaternion.identity);
        splashParticleGO.transform.GetChild(0).gameObject.transform.localScale = new Vector3(baseSizing, baseSizing, baseSizing); // decrease Size

        splashParticleGO.transform.position = Vector3.MoveTowards(splashParticleGO.transform.position, transform.position, 6 * Time.deltaTime);
        Destroy(splashParticleGO, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObjectBehaviourSystem>())
        {
            if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Lithium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // LITHIUM
            {
                Debug.Log("REACTED Lithium!");
                createSmoke();
                createFire(0.1f);
                Destroy(this.gameObject, lifeTime);

            }else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Sodium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // SODIUM
            {
                Debug.Log("REACTED Sodium!");
                createSmoke();
                createSparks();
                Destroy(this.gameObject, lifeTime);
            } else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Francium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // FRANCIUM
            {
                Debug.Log("REACTED Francium!");
                createSmoke();
                createSparks();
                createFire(0.3f);

                Destroy(this.gameObject, lifeTime);
            } else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Cesium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // Cesium
            {
                Debug.Log("REACTED Cesium!");
                createSmoke();


                Destroy(this.gameObject, lifeTime);
            } else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Potassium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // Potassium
            {
                Debug.Log("REACTED Potassium!");
                createSmoke();


                Destroy(this.gameObject, lifeTime);
            } else if (this.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Rubidium" && other.gameObject.GetComponent<ObjectBehaviourSystem>().objectId == "Water") // Rubidium
            {
                Debug.Log("REACTED Rubidium!");
                createSmoke();


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
