using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EggImpact : MonoBehaviour
{
    //You must assign to these two GameObjects in the Inspector
    //public GameObject m_MyObject;

    //clockwise around egg
    int[] hitZoneAngles = new int[5] {65,-10,-90,-170,115};

    EggStats eggStats;

    void Start()
    {
        eggStats = GetComponent<EggStats>();
    }

    void Update()
    {
        //GetAngleOfImpact(m_MyObject.transform.position);
    }

    float GetAngleOfImpact(Vector3 hitPosition, GameObject target)
    {
        //get angle between this game object and m_MyObject and take into account this game object's rotation
        Vector2 m_MySecondVector = hitPosition - target.transform.position;
        float m_SignedAngle = Vector2.Angle(m_MySecondVector, target.transform.right);
        Debug.DrawLine(Vector2.zero, m_MySecondVector, Color.blue);
        //turn mysecondvector to local space
        m_MySecondVector = target.transform.InverseTransformDirection(m_MySecondVector);
        if (m_MySecondVector.y < 0)
        {
            m_SignedAngle = -m_SignedAngle;
        }
        
        //Debug.Log("Signed Angle: " + m_SignedAngle);
        /*if (m_SignedAngle > hitZoneAngles[0] && m_SignedAngle < hitZoneAngles[4]){
            Debug.Log("Tip Hit!!!");
        } else if(m_SignedAngle > hitZoneAngles[1] && m_SignedAngle < hitZoneAngles[0]){
            Debug.Log("Right top!!!");
        } else if(m_SignedAngle > hitZoneAngles[2] && m_SignedAngle < hitZoneAngles[1]){
            Debug.Log("Right Bottom!!!");
        } else if(m_SignedAngle > hitZoneAngles[3] && m_SignedAngle < hitZoneAngles[2]){
            Debug.Log("Left Bottom!!!");
        } else if(m_SignedAngle > hitZoneAngles[4] || m_SignedAngle < hitZoneAngles[3]){
            Debug.Log("Left Top!!!");
        }*/

        return m_SignedAngle;
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
            //Debug.Log("Impact force: " + force);

            if(force>.1f){

                Vector2 sum = new Vector2(0,0);
                int amount = 0;
                for(int i = 0; i < col.contactCount; i++){
                    sum += col.GetContact(i).point;
                    amount++;
                }
                Vector2 averagePos = sum / amount;

                float hitAngle = GetAngleOfImpact(averagePos, gameObject);
                float targetHitAngle = GetAngleOfImpact(averagePos, col.gameObject);
                
                int targetHitZone = 0;
                if (targetHitAngle > hitZoneAngles[0] && targetHitAngle < hitZoneAngles[4]){
                    targetHitZone = 0;
                } else if(targetHitAngle > hitZoneAngles[1] && targetHitAngle < hitZoneAngles[0]){
                    targetHitZone = 1;
                } else if(targetHitAngle > hitZoneAngles[2] && targetHitAngle < hitZoneAngles[1]){
                    targetHitZone = 2;
                } else if(targetHitAngle > hitZoneAngles[3] && targetHitAngle < hitZoneAngles[2]){
                    targetHitZone = 3;
                } else if(targetHitAngle > hitZoneAngles[4] || targetHitAngle < hitZoneAngles[3]){
                    targetHitZone = 4;
                }

                if (hitAngle > hitZoneAngles[0] && hitAngle < hitZoneAngles[4]){
                    Debug.Log("Tip Hit!!!");
                    col.transform.GetComponent<EggStats>().TakeImpactDamage(eggStats.CalcImpactValue(0), targetHitZone);
                } else if(hitAngle > hitZoneAngles[1] && hitAngle < hitZoneAngles[0]){
                    Debug.Log("Right top!!!");
                    col.transform.GetComponent<EggStats>().TakeImpactDamage(eggStats.CalcImpactValue(1), targetHitZone);
                } else if(hitAngle > hitZoneAngles[2] && hitAngle < hitZoneAngles[1]){
                    Debug.Log("Right Bottom!!!");
                    col.transform.GetComponent<EggStats>().TakeImpactDamage(eggStats.CalcImpactValue(2), targetHitZone);
                } else if(hitAngle > hitZoneAngles[3] && hitAngle < hitZoneAngles[2]){
                    Debug.Log("Left Bottom!!!");
                    col.transform.GetComponent<EggStats>().TakeImpactDamage(eggStats.CalcImpactValue(3), targetHitZone);
                } else if(hitAngle > hitZoneAngles[4] || hitAngle < hitZoneAngles[3]){
                    Debug.Log("Left Top!!!");
                    col.transform.GetComponent<EggStats>().TakeImpactDamage(eggStats.CalcImpactValue(4), targetHitZone);
                }
            }
        }
    }
}