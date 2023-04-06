using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script is attached to each HpMeter mask object in the UI and handles the depleting of the HpMeter

public class HpDepleteMeter : MonoBehaviour
{
    public RectTransform HpMeter;
    public RectTransform MaskBottomRef;
    private float maxHpY;
    private float maxHpHeight;
    private float minHpY;
    private float minHpHeight;

    private void Start()
    {
        maxHpY = HpMeter.anchoredPosition.y;
        maxHpHeight = HpMeter.sizeDelta.y;
        minHpY = MaskBottomRef.anchoredPosition.y;
        minHpHeight = MaskBottomRef.sizeDelta.y;
    }

    public void SetHp(float hp)
    {
        HpMeter.anchoredPosition = new Vector2(HpMeter.anchoredPosition.x, Mathf.Lerp(minHpY, maxHpY, hp));
        HpMeter.sizeDelta = new Vector2(HpMeter.sizeDelta.x, Mathf.Lerp(minHpHeight, maxHpHeight, hp));
    }
}
