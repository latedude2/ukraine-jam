using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowEnemyEgg : MonoBehaviour
{
    void Start()
    {
        GetComponent<Image>().sprite = GameObject.Find("Egg - Enemy").GetComponent<EggManager>().EggSprite;
        GetComponent<Image>().color = GameObject.Find("Egg - Enemy").GetComponent<EggManager>().EggColor;
    }
}
