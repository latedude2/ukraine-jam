using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggUpgrade : MonoBehaviour
{
    public void IncreaseEggTopThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessTop += 15;
    }

    public void IncreaseEggBottomRightThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessBottomRight += 25;
    }

    public void IncreaseEggBottomLeftThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessBottomLeft += 25;
    }

    public void IncreaseEggTopLeftThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessTopLeft += 10;
    }

    public void IncreaseEggTopRightThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessTopRight += 10;
    }

    public void IncreaseEggTipSharpness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggTipSharpness += .1f;
    }

    public void IncreaseEggSlipperyness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggSlipperyness += 1;
    }
}
