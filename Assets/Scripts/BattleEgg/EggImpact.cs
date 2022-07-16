using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class EggImpact : MonoBehaviour
{
    //You must assign to these two GameObjects in the Inspector
    //public GameObject m_MyObject;

    //clockwise around egg
    int[] hitZoneAngles = new int[5] {65,-10,-90,-170,115};
    GameObject enemyEgg;
    AudioSource slowmoSource;

    [SerializeField] GameObject impactShellParticle;
    [SerializeField] GameObject impactCollisionParticle;

    EggStats eggStats;
    private float fixedDeltaTime;
    
    CheerManager cheerManager;
    public AudioMixerSnapshot slowmoSnapshot;
    public AudioMixerSnapshot defaultSnapshot;
    public float transitionTime = 1;
    private bool slowmoOn = false;

    void Start()
    {
        eggStats = GetComponent<EggStats>();
        slowmoSource = GameObject.FindWithTag("SlowmoSounds").GetComponent<AudioSource>();
        cheerManager = GameObject.Find("CheerManager").GetComponent<CheerManager>();
    }

    void Update()
    {
        //GetAngleOfImpact(m_MyObject.transform.position);
        Slowmo();
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
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Slowmo(){
        if(enemyEgg != null && GetComponent<EggStats>().isPlayer){
            float dist = Vector3.Distance(enemyEgg.transform.position, transform.position);
            if (dist < 1){
                Vector2 relativeVelocity = transform.GetComponent<Rigidbody2D>().velocity - enemyEgg.GetComponent<Rigidbody2D>().velocity;
                if (relativeVelocity.magnitude > 20){
                    //Debug.Log("Slowmo: " + transform.GetComponent<Rigidbody2D>().velocity.magnitude);
                    Time.timeScale = .1f;
                    slowmoSource.volume = .7f;
                    slowmoSource.pitch = .1f;
                    if (!slowmoOn) {
                        slowmoSnapshot.TransitionTo(transitionTime/Time.timeScale);
                        slowmoOn = true;
                    }
                } 
            } else if (dist < 2){
                //calculate relative velocity between enemy rigidbody and player rigidbody
                Vector2 relativeVelocity = transform.GetComponent<Rigidbody2D>().velocity - enemyEgg.GetComponent<Rigidbody2D>().velocity;
                if (relativeVelocity.magnitude > 20){
                //Debug.Log("Slowmo: " + transform.GetComponent<Rigidbody2D>().velocity.magnitude);
                Time.timeScale = .2f;
                slowmoSource.volume = Mathf.Lerp(.7f, .0f, dist-1);
                slowmoSource.pitch = Mathf.Lerp(.1f, .8f, dist-1);
                    if (!slowmoOn) {
                        slowmoSnapshot.TransitionTo(transitionTime/Time.timeScale);
                        slowmoOn = true;
                    }
                }
            } else {
                Time.timeScale = 1.0f;
                slowmoSource.volume = 0;
                slowmoSource.pitch = .8f;
                if (slowmoOn) {
                    defaultSnapshot.TransitionTo(transitionTime/Time.timeScale);
                    slowmoOn = false;
                }
            }
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        } else {
                // slowmoSource.volume = 0;
                // slowmoSource.pitch = .8f;
                // defaultSnapshot.TransitionTo(transitionTime/Time.timeScale);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Egg")
        {
            enemyEgg = col.gameObject;
            float force = 0;
            for(int i = 0; i < col.contactCount; i++){
                force += Mathf.Abs(col.GetContact(i).normalImpulse);
            }
            force /= col.contactCount;
            //Debug.Log("Impact force: " + force);

            if(force > 6f){

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
                if(force > 20f)
                {
                    cheerManager.PlayCheer();
                }
                //instantiate impact particle at averagePos
                GameObject impactParticle = Instantiate(impactCollisionParticle, averagePos, Quaternion.identity) as GameObject;
                Destroy(impactParticle, 3f);
                //instantiate impact particle at averagePos
                impactParticle = Instantiate(impactShellParticle, averagePos, Quaternion.identity) as GameObject;
                ParticleSystem.MainModule settings = impactParticle.GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(eggStats.tex.GetPixels32()[Random.Range(0,eggStats.tex.GetPixels32().Length)]*GetComponent<SpriteRenderer>().color);
                Destroy(impactParticle, 3f);

                //Debug.Log("Force: " + force);

                if (hitAngle > hitZoneAngles[0] && hitAngle < hitZoneAngles[4]){
                    col.transform.GetComponent<EggStats>().TakeImpactDamage(eggStats.CalcImpactValue(0, force), targetHitZone);
                } else if(hitAngle > hitZoneAngles[1] && hitAngle < hitZoneAngles[0]){
                    col.transform.GetComponent<EggStats>().TakeImpactDamage(eggStats.CalcImpactValue(1, force), targetHitZone);
                } else if(hitAngle > hitZoneAngles[2] && hitAngle < hitZoneAngles[1]){
                    col.transform.GetComponent<EggStats>().TakeImpactDamage(eggStats.CalcImpactValue(2, force), targetHitZone);
                } else if(hitAngle > hitZoneAngles[3] && hitAngle < hitZoneAngles[2]){
                    col.transform.GetComponent<EggStats>().TakeImpactDamage(eggStats.CalcImpactValue(3, force), targetHitZone);
                } else if(hitAngle > hitZoneAngles[4] || hitAngle < hitZoneAngles[3]){
                    col.transform.GetComponent<EggStats>().TakeImpactDamage(eggStats.CalcImpactValue(4, force), targetHitZone);
                }
            }
        }
    }
}
