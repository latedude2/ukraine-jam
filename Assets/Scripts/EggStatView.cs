using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStatView : MonoBehaviour
{
    public GameObject[] eggs;

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
                eggs[0].transform.gameObject.GetComponent<UIEgg>().Select(true);
        }
    }
}