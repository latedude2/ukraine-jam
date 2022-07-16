using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthWarning : MonoBehaviour
{
    public enum EggSide {
        Top,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public Image top;
    public Image topLeft;
    public Image topRight;
    public Image bottomLeft;
    public Image bottomRight;
}
