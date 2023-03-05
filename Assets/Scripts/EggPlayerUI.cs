using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggPlayerUI : MonoBehaviour
{
    public GameObject[] eggUIHealth = new GameObject[5];
    public HealthWarning healthWarning;
    BattleUI healthUI;

    // Start is called before the first frame update
    void Start()
    {
        healthUI = FindObjectOfType<BattleUI>();
        healthWarning = GameObject.FindObjectOfType<HealthWarning>();
    }

}
