using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Egg manager keeps track of the player's stats
public class EggManager : MonoBehaviour
{
    //Stats - do not change in battle
    //-----------------------
    public float EggThicknessTop = 100f;
    public float EggThicknessBottomRight = 100f;
    public float EggThicknessBottomLeft = 100f;
    public float EggThicknessTopLeft = 100f;
    public float EggThicknessTopRight = 100f;
    public float EggTipSharpness = 1f;
    public float EggGrip = 1f; //The bigger the grip the more force for the spring to break
    public Sprite EggSprite;
    public Color EggColor;
}
