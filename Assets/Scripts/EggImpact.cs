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
            float force = 0;
            for(int i = 0; i < col.contactCount; i++){
                force += Mathf.Abs(col.GetContact(i).normalImpulse);
            }
            force /= col.contactCount;
            Debug.Log(force);

            if(force>.1f){

                // Print how many points are colliding with this transform
                Debug.Log("Points colliding: " + col.GetContact(0));

                // Print the normal of the first point in the collision.
                Debug.Log("Normal of the first point: " + col.GetContact(0).normal);

                // Draw a different colored ray for every normal in the collision
                Vector2 point = new Vector2(0,0);
                Vector2 normal = new Vector2(0,0);
                
                foreach (var item in col.contacts)
                {
                //Debug.DrawRay(item.point, item.normal * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
                point = item.point;
                normal += item.normal;
                
                }

                Debug.DrawRay(point, normal * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
            }
        }
    }
}
