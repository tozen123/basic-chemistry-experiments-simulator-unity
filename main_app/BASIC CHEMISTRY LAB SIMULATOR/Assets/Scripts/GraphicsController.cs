using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class GraphicsController : MonoBehaviour
{
    PostProcessVolume v;

    public Bloom pp_Bloom;
    public AmbientOcclusion pp_AmbientOcclusion;

    public bool ppobject = true;
    public bool ppobject1 = true;
    public bool ppobject2 = true;
    public bool ppobject3 = true;

    private void Start()
    {
        v = GetComponent<PostProcessVolume>();
        v.profile.TryGetSettings(out pp_Bloom);
        v.profile.TryGetSettings(out pp_AmbientOcclusion);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (ppobject)
            {
                v.isGlobal = false;
                ppobject = false;
            } else
            {
                v.isGlobal = true;
                ppobject = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (ppobject1)
            {
                pp_Bloom.active = false;
                ppobject1 = false;
            }
            else
            {
                pp_Bloom.active = true;
                ppobject1 = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (ppobject2)
            {
                pp_AmbientOcclusion.active = false;
                ppobject2 = false;
            }
            else
            {
                pp_AmbientOcclusion.active = true;
                ppobject2 = true;
            }
        }
    }
}
