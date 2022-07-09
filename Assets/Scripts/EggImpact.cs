using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EggImpact : MonoBehaviour
{

    
    Vector2 m_MySecondVector;

    float m_SignedAngle;

    //You must assign to these two GameObjects in the Inspector
    public GameObject m_MyObject;

    void Start()
    {
        //Initialise the Vector
        m_MySecondVector = Vector2.zero;
        m_SignedAngle = 0.0f;
    }

    void Update()
    {
        //Fetch the second GameObject's position
        m_MySecondVector = new Vector2(m_MyObject.transform.position.x-gameObject.transform.position.x, m_MyObject.transform.position.y-gameObject.transform.position.y);
        //Find the angle for the two Vectors
        Debug.Log("Egg rot: " + gameObject.transform.rotation.eulerAngles.z);

        m_SignedAngle = Vector2.SignedAngle(new Vector2(0,1), m_MySecondVector);

        Debug.DrawLine(Vector2.zero, m_MySecondVector, Color.blue);

        //Log values of Vectors and angle in Console
        //Debug.Log("MyFirstVector: " + m_MyFirstVector);
        //Debug.Log("MySecondVector: "  + m_MySecondVector);
        Debug.Log("Angle Between Objects: " + m_SignedAngle);
        Debug.Log("sine " + Mathf.Sin((m_SignedAngle * Mathf.PI)/180));

        if (m_SignedAngle > 160+gameObject.transform.rotation.eulerAngles.z && m_SignedAngle < 200+gameObject.transform.rotation.eulerAngles.z){
                    Debug.Log("Tip Hit!!!");
                }
        //float angle = Vector2.SignedAngle(gameObject.transform.up, m_MyObject.transform.up);
        //Debug.Log("angle " + angle);
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
            Debug.Log("Impact force: " + force);

            if(force>.1f){

                Vector2 sum = new Vector2(0,0);
                int amount = 0;
                for(int i = 0; i < col.contactCount; i++){
                    sum += col.GetContact(i).point;
                    amount++;
                }
                Vector2 averagePos = sum / amount;
                
                Vector2 hitVector = new Vector2(averagePos.x-gameObject.transform.position.x, averagePos.y-gameObject.transform.position.y);
                float hitAngle = Vector2.SignedAngle(new Vector2(0,1), hitVector);
                //Debug.DrawLine(gameObject.transform.position, m_MySecondVector, Color.blue);

                if (hitAngle > 160+gameObject.transform.rotation.eulerAngles.z && hitAngle < 200+gameObject.transform.rotation.eulerAngles.z){
                    //Debug.Log("Tip Hit!!!");
                }
            }
        }
    }
}
