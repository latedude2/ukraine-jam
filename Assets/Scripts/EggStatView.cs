using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EggStatView : MonoBehaviour
{
    public GameObject[] eggs;

    Text tipSharpness;
    Text slipperyness;
    Text thicknessTop;
    Text thicknessBottomRight;
    Text thicknessBottomLeft;
    Text thicknessTopLeft;
    Text thicknessTopRight;


    void Start()
    {
        //get reference to Tip Sharpness gameobject
        tipSharpness = GameObject.Find("TipSharpness").GetComponent<Text>();
        slipperyness = GameObject.Find("EggSlipperyness").GetComponent<Text>();
        thicknessTop = GameObject.Find("TopThickness").GetComponent<Text>();
        thicknessBottomRight = GameObject.Find("BottomRightThickness").GetComponent<Text>();
        thicknessBottomLeft = GameObject.Find("BottomLeftThickness").GetComponent<Text>();
        thicknessTopLeft = GameObject.Find("TopLeftThickness").GetComponent<Text>();
        thicknessTopRight = GameObject.Find("TopRightThickness").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
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
                slipperyness.text = chosenEggManager.EggSlipperyness.ToString();
                tipSharpness.text = chosenEggManager.EggTipSharpness.ToString();
                if(Input.GetMouseButtonDown(0))
                {
                    EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
                    eggManager.EggSlipperyness = chosenEggManager.EggSlipperyness;
                    eggManager.EggTipSharpness = chosenEggManager.EggTipSharpness;
                    eggManager.EggThicknessTop = chosenEggManager.EggThicknessTop;
                    eggManager.EggThicknessBottomRight = chosenEggManager.EggThicknessBottomRight;
                    eggManager.EggThicknessBottomLeft = chosenEggManager.EggThicknessBottomLeft;
                    eggManager.EggThicknessTopLeft = chosenEggManager.EggThicknessTopLeft;
                    eggManager.EggThicknessTopRight = chosenEggManager.EggThicknessTopRight;
                    
                    //Load battle scene
                    SceneManager.LoadScene("Battle");
                }
            }
        }
    }
}