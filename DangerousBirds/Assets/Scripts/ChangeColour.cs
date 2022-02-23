using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public Color[] colors;
    Color firstColor;
    Color secondColor;
    public Material platformMaterial;
    void Start()
    {
        int br_color = Random.Range(0, colors.Length);
        platformMaterial.color = colors[br_color];
        int ik_color = Random.Range(0, colors.Length);
        secondColor=colors[ik_color];
    }

    
    void Update()
    {
        Color fark=platformMaterial.color-secondColor;
        if (Mathf.Abs(fark.r) + Mathf.Abs(fark.g) + Mathf.Abs(fark.b) < 0.2f)
        {
            int ik_color = Random.Range(0, colors.Length);
            secondColor = colors[ik_color];
           
        }
        platformMaterial.color = Color.Lerp(platformMaterial.color, secondColor, 0.003f);
    }
}
