using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GramsController : MonoBehaviour
{
    public float GramsToAdd;

    public TextMeshProUGUI text;
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
        GramsToAdd += 1;
    }

    public void reduceGrams()
    {
        GramsToAdd -= 1;
    }
}
