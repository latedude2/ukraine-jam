using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerEgg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = GameObject.Find("PlayerStats").GetComponent<EggManager>().EggSprite;
        GetComponent<Image>().color = GameObject.Find("PlayerStats").GetComponent<EggManager>().EggColor;
    }

}
