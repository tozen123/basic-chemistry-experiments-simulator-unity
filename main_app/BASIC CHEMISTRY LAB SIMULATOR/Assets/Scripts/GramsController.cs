using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GramsController : MonoBehaviour
{
    public float GramsToAdd;

    private float MaxLimit = 20;
    private float MinLimit = 1;



    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GramsToAdd.ToString("0") + " gram(s)";
    }

    public void addGrams()
    {
        if((GramsToAdd == MaxLimit) == false)
        {
            GramsToAdd += 1;
        } else
        {
            text2.text = "YOU CAN'T FURTHER ADD MORE GRAMS, AS THE LIMIT OF THE SIMULATOR is 20!";
        }
        
    }

    public void reduceGrams()
    {
        if ((GramsToAdd == MinLimit) == false)
        {
            GramsToAdd -= 1;
        }
        else
        {
            text2.text = "YOU CAN'T FURTHER REDUCE GRAMS, AS NEGATIVES IS NOT APPLICABLE.";
        }

    }
}
