using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipWindow : MonoBehaviour
{
    public CanvasGroup tip0;

    bool fadeIn = false;

    public float timer = 2f;
    void Awake()
    {
        fadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer > -6f)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            if (fadeIn == true)
            {
                if (tip0.alpha < 1)
                {
                    tip0.alpha += Time.deltaTime;
                    if (tip0.alpha >= 1)
                    {
                        fadeIn = false;
                    }
                }
            }
        }

        if (timer <= -2.1f)
        {
            if (fadeIn == false)
            {
                tip0.alpha -= Time.deltaTime;
            }
        }

    }
}
