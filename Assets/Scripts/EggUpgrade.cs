using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggUpgrade : MonoBehaviour
{
    public void IncreaseEggTopThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessTop += 30;
    }

    public void IncreaseEggBottomSideThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessBottomRight += 25;
        eggManager.EggThicknessBottomLeft += 25;
    }

    public void IncreaseEggTopSideThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessTopRight += 15;
        eggManager.EggThicknessTopLeft += 15;
    }

    public void IncreaseEggTipSharpness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggTipSharpness += .1f;
    }

    public void IncreaseEggGrip()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggGrip += .3f;
    }
}
