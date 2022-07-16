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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUIHealth(bool isPlayer){
        // Color c = Color.red;
        // if (isPlayer)
        // {
        //     healthUI.playerUI.top.color = new Color(c.r, c.g, c.b, 1 - GetComponent<EggStats>().currentHealthTop / 100f);
        //     healthUI.playerUI.topLeft.color = new Color(c.r, c.g, c.b, 1 - GetComponent<EggStats>().currentHealthTopLeft / 100f);
        //     healthUI.playerUI.topRight.color = new Color(c.r, c.g, c.b, 1 - GetComponent<EggStats>().currentHealthTopRight / 100f);
        //     healthUI.playerUI.bottomLeft.color = new Color(c.r, c.g, c.b, 1 - GetComponent<EggStats>().currentHealthBottomLeft / 100f);
        //     healthUI.playerUI.bottomRight.color = new Color(c.r, c.g, c.b, 1 - GetComponent<EggStats>().currentHealthBottomRight / 100f);
        // }
        // else
        // {
        //     healthUI.enemyUI.top.color = new Color(c.r, c.g, c.b, 1 - GetComponent<EggStats>().currentHealthTop / 100f);
        //     healthUI.enemyUI.topLeft.color = new Color(c.r, c.g, c.b, 1 - GetComponent<EggStats>().currentHealthTopLeft / 100f);
        //     healthUI.enemyUI.topRight.color = new Color(c.r, c.g, c.b, 1 - GetComponent<EggStats>().currentHealthTopRight / 100f);
        //     healthUI.enemyUI.bottomLeft.color = new Color(c.r, c.g, c.b, 1 - GetComponent<EggStats>().currentHealthBottomLeft / 100f);
        //     healthUI.enemyUI.bottomRight.color = new Color(c.r, c.g, c.b, 1 - GetComponent<EggStats>().currentHealthBottomRight / 100f);

        // }
        // eggUIHealth[0].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthTop) + "%";
        // eggUIHealth[1].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthTopRight) + "%";
        // eggUIHealth[2].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthBottomRight) + "%";
        // eggUIHealth[3].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthBottomLeft) + "%";
        // eggUIHealth[4].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthTopLeft) + "%";
    }
}
