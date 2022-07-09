using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggUpgrade : MonoBehaviour
{
    public void IncreaseEggTopThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerState").GetComponent<EggManager>();
        eggManager.EggThicknessTop += 1;
    }

    public void IncreaseEggBottomRightThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerState").GetComponent<EggManager>();
        eggManager.EggThicknessBottomRight += 1;
    }

    public void IncreaseEggBottomLeftThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerState").GetComponent<EggManager>();
        eggManager.EggThicknessBottomLeft += 1;
    }

    public void IncreaseEggTopLeftThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerState").GetComponent<EggManager>();
        eggManager.EggThicknessTopLeft += 1;
    }

    public void IncreaseEggTopRightThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerState").GetComponent<EggManager>();
        eggManager.EggThicknessTopRight += 1;
    }

    public void IncreaseEggTipSharpness()
    {
        EggManager eggManager = GameObject.Find("PlayerState").GetComponent<EggManager>();
        eggManager.EggTipSharpness += 1;
    }

    public void IncreaseEggSlipperyness()
    {
        EggManager eggManager = GameObject.Find("PlayerState").GetComponent<EggManager>();
        eggManager.EggSlipperyness += 1;
    }
}
