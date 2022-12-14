using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherSystem : MonoBehaviour
{
    public GameObject extinguisherParticle;
    private void Start()
    {
        extinguisherParticle.GetComponent<ParticleSystem>().Stop();
    }
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (this.gameObject.activeSelf == true)
            {
                this.gameObject.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            extinguisherParticle.GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            extinguisherParticle.GetComponent<ParticleSystem>().Stop();
        }
    }
}
