using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggUpgrade : MonoBehaviour
{
    public void IncreaseEggTopThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessTop += 10;
    }

    public void IncreaseEggBottomRightThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessBottomRight += 20;
    }

    public void IncreaseEggBottomLeftThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessBottomLeft += 20;
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

    public void IncreaseEggGrip()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggGrip += 1;
    }
}
