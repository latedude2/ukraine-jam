using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggPlayerUI : MonoBehaviour
{
    public GameObject[] eggUIHealth = new GameObject[5];
    public HealthWarning healthWarning;

    // Start is called before the first frame update
    void Start()
    {
        healthWarning = GameObject.FindObjectOfType<HealthWarning>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUIHealth(){
        Color c = Color.red;
        healthWarning.top.color = new Color(c.r, c.g, c.b, GetComponent<EggStats>().currentHealthTop);
        healthWarning.topLeft.color = new Color(c.r, c.g, c.b, GetComponent<EggStats>().currentHealthTopLeft);
        healthWarning.topRight.color = new Color(c.r, c.g, c.b, GetComponent<EggStats>().currentHealthTopRight);
        healthWarning.bottomLeft.color = new Color(c.r, c.g, c.b, GetComponent<EggStats>().currentHealthBottomLeft);
        healthWarning.bottomRight.color = new Color(c.r, c.g, c.b, GetComponent<EggStats>().currentHealthBottomRight);
        // eggUIHealth[0].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthTop) + "%";
        // eggUIHealth[1].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthTopRight) + "%";
        // eggUIHealth[2].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthBottomRight) + "%";
        // eggUIHealth[3].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthBottomLeft) + "%";
        // eggUIHealth[4].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthTopLeft) + "%";
    }
}
