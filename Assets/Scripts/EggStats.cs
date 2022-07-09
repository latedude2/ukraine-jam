using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStats : MonoBehaviour
{
    //-----------------------

    //Values that change in battle
    float currentHealthTop = 100f;
    float currentHealthBottomRight = 100f;
    float currentHealthBottomLeft = 100f;
    float currentHealthTopLeft = 100f;
    float currentHealthTopRight = 100f;

    //Stats - do not change in battle
    //-----------------------
    public float EggThicknessTop = 100f;
    public float EggThicknessBottomRight = 100f;
    public float EggThicknessBottomLeft = 100f;
    public float EggThicknessTopLeft = 100f;
    public float EggThicknessTopRight = 100f;
    public float EggTipSharpness = 1f;
    public float EggSlipperyness = 1f; //The bigger the slipperyness the less force for the spring to break

    void Start()
    {
        //if egg is player, take stats from manager
        if(GetComponent<EggControl>() != null) 
        {
            EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
            EggThicknessTop = eggManager.EggThicknessTop;
            EggThicknessBottomLeft = eggManager.EggThicknessBottomLeft;
            EggThicknessBottomRight = eggManager.EggThicknessBottomRight;
            EggThicknessTopLeft = eggManager.EggThicknessTopLeft;
            EggThicknessTopRight = eggManager.EggThicknessTopRight;
            EggTipSharpness = eggManager.EggTipSharpness;
            EggSlipperyness = eggManager.EggSlipperyness;
            GetComponent<SpriteRenderer>().sprite = eggManager.EggSprite;
            GetComponent<SpriteRenderer>().color = eggManager.EggColor;
        }
    }
    
}
