using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggUpgrade : MonoBehaviour
{
    public void IncreaseEggTopThickness()
    {
        EggManager eggManager = GetComponent<EggManager>();
        eggManager.EggThicknessTop += 1;
    }

    public void IncreaseEggBottomRightThickness()
    {
        EggManager eggManager = GetComponent<EggManager>();
        eggManager.EggThicknessBottomRight += 1;
    }

    public void IncreaseEggBottomLeftThickness()
    {
        EggManager eggManager = GetComponent<EggManager>();
        eggManager.EggThicknessBottomLeft += 1;
    }

    public void IncreaseEggTopLeftThickness()
    {
        EggManager eggManager = GetComponent<EggManager>();
        eggManager.EggThicknessTopLeft += 1;
    }

    public void IncreaseEggTopRightThickness()
    {
        EggManager eggManager = GetComponent<EggManager>();
        eggManager.EggThicknessTopRight += 1;
    }

    public void IncreaseEggTipSharpness()
    {
        EggManager eggManager = GetComponent<EggManager>();
        eggManager.EggTipSharpness += 1;
    }

    public void IncreaseEggSlipperyness()
    {
        EggManager eggManager = GetComponent<EggManager>();
        eggManager.EggSlipperyness += 1;
    }
}
