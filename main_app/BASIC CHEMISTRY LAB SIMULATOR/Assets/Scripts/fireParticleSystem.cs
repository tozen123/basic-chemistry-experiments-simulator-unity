using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireParticleSystem : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.name == "Extinguisher")
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
