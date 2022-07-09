using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStats : MonoBehaviour
{
    //-----------------------''
    bool isPlayer = false;

    //Values that change in battle
    public float currentHealthTop = 100f;
    public float currentHealthBottomRight = 100f;
    public float currentHealthBottomLeft = 100f;
    public float currentHealthTopLeft = 100f;
    public float currentHealthTopRight = 100f;

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
        if (GetComponent<EggControl>() != null) {
            isPlayer = true;
        }
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

    public float CalcImpactValue(int side, float force) {
        if (side == 0) {    //tip
            return force * 500f * EggTipSharpness;
        } else if (side == 1){  //right top
            return force * 500f;
        } else if (side == 2){  //right bottom
            return force * 500f;
        } else if (side == 3){  //left bottom
            return force * 500f;
        } else if (side == 4){  //left top
            return force * 500f;
        }
        return 0;
    }

    public void TakeImpactDamage(float incomingDamage, int side) {
        Debug.Log("Incoming damage: " + incomingDamage + "; Side: " + side);
        if (side == 0) {    //tip
            currentHealthTop -= incomingDamage / EggThicknessTop;
        } else if (side == 1){  //right top
            currentHealthTopRight -= incomingDamage / EggThicknessTopRight;
        } else if (side == 2){  //right bottom
            currentHealthBottomRight -= incomingDamage / EggThicknessBottomRight;
        } else if (side == 3){  //left bottom
            currentHealthBottomLeft -= incomingDamage / EggThicknessBottomLeft;
        } else if (side == 4){  //left top
            currentHealthTopLeft -= incomingDamage / EggThicknessTopLeft; 
        }

        if (isPlayer){
            GetComponent<EggPlayerUI>().UpdateUIHealth();
        }
    }
}
