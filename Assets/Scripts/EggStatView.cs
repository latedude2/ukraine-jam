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
                thicknessTop.text = eggs[0].transform.gameObject.GetComponent<EggManager>().EggThicknessTop.ToString();
                thicknessBottomRight.text = eggs[0].transform.gameObject.GetComponent<EggManager>().EggThicknessBottomRight.ToString();
                thicknessBottomLeft.text = eggs[0].transform.gameObject.GetComponent<EggManager>().EggThicknessBottomLeft.ToString();
                thicknessTopLeft.text = eggs[0].transform.gameObject.GetComponent<EggManager>().EggThicknessTopLeft.ToString();
                thicknessTopRight.text = eggs[0].transform.gameObject.GetComponent<EggManager>().EggThicknessTopRight.ToString();
                slipperyness.text = eggs[0].transform.gameObject.GetComponent<EggManager>().EggSlipperyness.ToString();
                tipSharpness.text = eggs[0].transform.gameObject.GetComponent<EggManager>().EggTipSharpness.ToString();
                if(Input.GetMouseButtonDown(0))
                {
                    GameObject.Find("PlayerStats").GetComponent<EggManager>().EggSlipperyness = eggs[0].transform.gameObject.GetComponent<EggManager>().EggSlipperyness;
                    GameObject.Find("PlayerStats").GetComponent<EggManager>().EggTipSharpness = eggs[0].transform.gameObject.GetComponent<EggManager>().EggTipSharpness;
                    GameObject.Find("PlayerStats").GetComponent<EggManager>().EggThicknessTop = eggs[0].transform.gameObject.GetComponent<EggManager>().EggThicknessTop;
                    GameObject.Find("PlayerStats").GetComponent<EggManager>().EggThicknessBottomRight = eggs[0].transform.gameObject.GetComponent<EggManager>().EggThicknessBottomRight;
                    GameObject.Find("PlayerStats").GetComponent<EggManager>().EggThicknessBottomLeft = eggs[0].transform.gameObject.GetComponent<EggManager>().EggThicknessBottomLeft;
                    GameObject.Find("PlayerStats").GetComponent<EggManager>().EggThicknessTopLeft = eggs[0].transform.gameObject.GetComponent<EggManager>().EggThicknessTopLeft;
                    GameObject.Find("PlayerStats").GetComponent<EggManager>().EggThicknessTopRight = eggs[0].transform.gameObject.GetComponent<EggManager>().EggThicknessTopRight;
                    //Load battle scene
                    SceneManager.LoadScene("Battle");
                }
            }
        }
    }
}