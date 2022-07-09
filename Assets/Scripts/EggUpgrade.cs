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

    public void IncreaseEggBottomSideThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessBottomRight += 20;
        eggManager.EggThicknessBottomLeft += 20;
    }

    public void IncreaseEggTopSideThickness()
    {
        EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
        eggManager.EggThicknessTopRight += 10;
        eggManager.EggThicknessTopLeft += 10;
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
