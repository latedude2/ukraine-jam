using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEggUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GameObject.Find("PlayerStats").GetComponent<EggManager>().EggSprite;
    }
}
