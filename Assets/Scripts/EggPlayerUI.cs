using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggPlayerUI : MonoBehaviour
{
    public GameObject[] eggUIHealth = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUIHealth(){
        eggUIHealth[0].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthTop) + "%";
        eggUIHealth[1].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthTopRight) + "%";
        eggUIHealth[2].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthBottomRight) + "%";
        eggUIHealth[3].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthBottomLeft) + "%";
        eggUIHealth[4].GetComponent<Text>().text = Mathf.Round(GetComponent<EggStats>().currentHealthTopLeft) + "%";
    }
}
