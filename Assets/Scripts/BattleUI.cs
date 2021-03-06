using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [System.Serializable]
    public struct HealthUI
    {
        public Image top;
        public Image topLeft;
        public Image topRight;
        public Image bottomLeft;
        public Image bottomRight;
    }

    public HealthUI playerUI;
    public HealthUI enemyUI;

    public Sprite[] topCracks = new Sprite[5];
    public Sprite[] topLeftCracks = new Sprite[5];
    public Sprite[] topRightCracks = new Sprite[5];
    public Sprite[] bottomLeftCracks = new Sprite[5];
    public Sprite[] bottomRightCracks = new Sprite[5];

    public void UpdateUIHealth(float top, float topLeft, float topRight, float bottomLeft, float bottomRight, bool isPlayer)
    {
        Color c = Color.red;
        if (isPlayer)
        {
            ProcessSide(playerUI.top, top, topCracks);
            ProcessSide(playerUI.topLeft, topLeft, topLeftCracks);
            ProcessSide(playerUI.topRight, topRight, topRightCracks);
            ProcessSide(playerUI.bottomLeft, bottomLeft, bottomLeftCracks);
            ProcessSide(playerUI.bottomRight, bottomRight, bottomRightCracks);
        }
        else
        {
            ProcessSide(enemyUI.top, top, topCracks);
            ProcessSide(enemyUI.topLeft, topLeft, topLeftCracks);
            ProcessSide(enemyUI.topRight, topRight, topRightCracks);
            ProcessSide(enemyUI.bottomLeft, bottomLeft, bottomLeftCracks);
            ProcessSide(enemyUI.bottomRight, bottomRight, bottomRightCracks);
        }
    }
    
    private void ProcessSide(Image uiElement, float value, Sprite[] cracks)
    {
        value = Mathf.Clamp01(1 - value / 100);
        uiElement.color = new Color(1, 0, 0, value);

        int step = 0;
        value *= 5;
        if (value < 5)
            step = Mathf.FloorToInt(value);
        else step = 4;
        uiElement.transform.GetChild(0).GetComponent<Image>().sprite = cracks[step];
    }
}
