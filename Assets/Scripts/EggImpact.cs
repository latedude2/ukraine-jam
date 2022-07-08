using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggImpact : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Egg")
        {
            float force = Mathf.Abs(col.GetContact(0).normalImpulse);
        }
    }
}
