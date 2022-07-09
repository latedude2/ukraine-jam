using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EggStatView : MonoBehaviour
{
    public GameObject[] eggs;

    Text tipSharpness;
    Text grip;
    Text thicknessTop;
    Text thicknessBottomRight;
    Text thicknessBottomLeft;
    Text thicknessTopLeft;
    Text thicknessTopRight;


    void Start()
    {
        //get reference to Tip Sharpness gameobject
        tipSharpness = GameObject.Find("TipSharpness").GetComponent<Text>();
        grip = GameObject.Find("EggSlipperyness").GetComponent<Text>();
        thicknessTop = GameObject.Find("TopThickness").GetComponent<Text>();
        thicknessBottomRight = GameObject.Find("BottomRightThickness").GetComponent<Text>();
        thicknessBottomLeft = GameObject.Find("BottomLeftThickness").GetComponent<Text>();
        thicknessTopLeft = GameObject.Find("TopLeftThickness").GetComponent<Text>();
        thicknessTopRight = GameObject.Find("TopRightThickness").GetComponent<Text>();
        //if loaded scene is upgrade
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ChooseEgg")
        {
            ShowHoveredEggStats();
        }
        else if (SceneManager.GetActiveScene().name == "UpgradeEgg")
        {
            ShowStatsInUpgradeScreen();
        }
    }

    void ShowStatsInUpgradeScreen()
    {
        if (SceneManager.GetActiveScene().name == "UpgradeEgg")
        {
            EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
            tipSharpness.text = eggManager.EggTipSharpness.ToString();
            grip.text = eggManager.EggGrip.ToString();
            thicknessTop.text = eggManager.EggThicknessTop.ToString();
            thicknessBottomRight.text = eggManager.EggThicknessBottomRight.ToString();
            thicknessBottomLeft.text = eggManager.EggThicknessBottomLeft.ToString();
            thicknessTopLeft.text = eggManager.EggThicknessTopLeft.ToString();
            thicknessTopRight.text = eggManager.EggThicknessTopRight.ToString();
        }
    }

    void ShowHoveredEggStats()
    {
        eggs = GameObject.FindGameObjectsWithTag("Egg");
        RaycastHit2D[] hit;
  
        foreach(GameObject egg in eggs)
        {
            egg.GetComponent<UIEgg>().Select(false);
        }     
        hit = Physics2D.RaycastAll(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
        if (hit.Length != 0) 
        {
            List<RaycastHit2D> hits = new List<RaycastHit2D>(hit);
            List<RaycastHit2D> eggs = hits.FindAll(singleHit => singleHit.transform.gameObject.tag == "Egg");
            if(eggs.Count != 0)
            {
                eggs[0].transform.gameObject.GetComponent<UIEgg>().Select(true);
                EggManager chosenEggManager = eggs[0].transform.gameObject.GetComponent<EggManager>();
                thicknessTop.text = chosenEggManager.EggThicknessTop.ToString();
                thicknessBottomRight.text = chosenEggManager.EggThicknessBottomRight.ToString();
                thicknessBottomLeft.text = chosenEggManager.EggThicknessBottomLeft.ToString();
                thicknessTopLeft.text = chosenEggManager.EggThicknessTopLeft.ToString();
                thicknessTopRight.text = chosenEggManager.EggThicknessTopRight.ToString();
                grip.text = chosenEggManager.EggGrip.ToString();
                tipSharpness.text = chosenEggManager.EggTipSharpness.ToString();
                if(Input.GetMouseButtonDown(0))
                {
                    EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
                    eggManager.EggGrip = chosenEggManager.EggGrip;
                    eggManager.EggTipSharpness = chosenEggManager.EggTipSharpness;
                    eggManager.EggThicknessTop = chosenEggManager.EggThicknessTop;
                    eggManager.EggThicknessBottomRight = chosenEggManager.EggThicknessBottomRight;
                    eggManager.EggThicknessBottomLeft = chosenEggManager.EggThicknessBottomLeft;
                    eggManager.EggThicknessTopLeft = chosenEggManager.EggThicknessTopLeft;
                    eggManager.EggThicknessTopRight = chosenEggManager.EggThicknessTopRight;
                    eggManager.EggSprite = chosenEggManager.GetComponent<SpriteRenderer>().sprite;
                    eggManager.EggColor = chosenEggManager.GetComponent<SpriteRenderer>().color;
                    //Load battle scene
                    SceneManager.LoadScene("Battle");
                }
            }
        }
    }
}