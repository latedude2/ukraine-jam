using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEgg : MonoBehaviour
{

    public void Select(bool select)
    {
        if(select) 
        {
            //enlarge the egg
            transform.localScale = new Vector3(.15f, .15f, .15f);
        }
        else{
            //shrink the egg
            transform.localScale = new Vector3(.1f, .1f, .1f);
        }
    }
}
