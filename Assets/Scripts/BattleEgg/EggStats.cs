using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStats : MonoBehaviour
{
    //-----------------------''
    bool isPlayer = false;

    AudioSource audioSource;
    public AudioClip[] audioClips;
    [SerializeField] GameObject destructionParticle;

    //Values that change in battle
    public float currentHealthTop = 100f;
    public float currentHealthBottomRight = 100f;
    public float currentHealthBottomLeft = 100f;
    public float currentHealthTopLeft = 100f;
    public float currentHealthTopRight = 100f;

    //Stats - do not change in battle
    //-----------------------
    public float EggThicknessTop = 100f;
    public float EggThicknessBottomRight = 100f;
    public float EggThicknessBottomLeft = 100f;
    public float EggThicknessTopLeft = 100f;
    public float EggThicknessTopRight = 100f;
    public float EggTipSharpness = 1f;
    public float EggGrip = 1f; //The bigger the grip the more force for the spring to break

    public Texture2D tex;

    void Start()
    {
        if (GetComponent<EggControl>() != null) {
            isPlayer = true;
            audioSource = Camera.main.GetComponent<AudioSource>();
        }
        //if egg is player, take stats from manager
        if(isPlayer) 
        {
            EggManager eggManager = GameObject.Find("PlayerStats").GetComponent<EggManager>();
            EggThicknessTop = eggManager.EggThicknessTop;
            EggThicknessBottomLeft = eggManager.EggThicknessBottomLeft;
            EggThicknessBottomRight = eggManager.EggThicknessBottomRight;
            EggThicknessTopLeft = eggManager.EggThicknessTopLeft;
            EggThicknessTopRight = eggManager.EggThicknessTopRight;
            EggTipSharpness = eggManager.EggTipSharpness;
            EggGrip = eggManager.EggGrip;
            GetComponent<SpriteRenderer>().sprite = eggManager.EggSprite;
            GetComponent<SpriteRenderer>().color = eggManager.EggColor;    
        }

        if(!isPlayer)
        {
            AdjustEnemyStatsBasedOnLevel();
        }
        tex = GetComponent<SpriteRenderer>().sprite.texture;
    }

    public void AdjustEnemyStatsBasedOnLevel()
    {
        Progression progression = GameObject.Find("PlayerStats").GetComponent<Progression>();
        int level = progression.Level;
        float levelMultiplier = (level-1) * 0.05f;   //5% per level increase to all stats
        EggThicknessTop = EggThicknessTop + (EggThicknessTop * levelMultiplier);
        EggThicknessBottomLeft = EggThicknessBottomLeft + (EggThicknessBottomLeft * levelMultiplier);
        EggThicknessBottomRight = EggThicknessBottomRight + (EggThicknessBottomRight * levelMultiplier);
        EggThicknessTopLeft = EggThicknessTopLeft + (EggThicknessTopLeft * levelMultiplier);
        EggThicknessTopRight = EggThicknessTopRight + (EggThicknessTopRight * levelMultiplier);
        EggTipSharpness = EggTipSharpness + (EggTipSharpness * levelMultiplier);
    }

    public float CalcImpactValue(int side, float force) {
        if (isPlayer){
            if (force < 40){
                audioSource.volume = force/40;
            } else {
                audioSource.volume = 1;
            }
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
        } 
        if (side == 0) {    //tip
            return force * 50f * EggTipSharpness;
        } else if (side == 1){  //right top
            return force * 50f;
        } else if (side == 2){  //right bottom
            return force * 50f;
        } else if (side == 3){  //left bottom
            return force * 50f;
        } else if (side == 4){  //left top
            return force * 50f;
        }
       
        return 0;
    }

    public void TakeImpactDamage(float incomingDamage, int side) {
        //Debug.Log("Incoming damage: " + incomingDamage + "; Side: " + side);
        if (side == 0) {    //tip
            currentHealthTop -= incomingDamage / EggThicknessTop;
        } else if (side == 1){  //right top
            currentHealthTopRight -= incomingDamage / EggThicknessTopRight;
        } else if (side == 2){  //right bottom
            currentHealthBottomRight -= incomingDamage / EggThicknessBottomRight;
        } else if (side == 3){  //left bottom
            currentHealthBottomLeft -= incomingDamage / EggThicknessBottomLeft;
        } else if (side == 4){  //left top
            currentHealthTopLeft -= incomingDamage / EggThicknessTopLeft; 
        }

        if (isPlayer){
            GetComponent<EggPlayerUI>().UpdateUIHealth();
            GameObject.Find("Main Camera").GetComponent<CameraShake>().shakeDuration = 0.2f;
        }

        if (currentHealthTop <= 0 || currentHealthTopLeft <= 0 || currentHealthBottomRight <= 0 || currentHealthBottomLeft <= 0 || currentHealthTopRight <= 0){
            GameObject burstParticle = Instantiate(destructionParticle, gameObject.transform.position, Quaternion.identity) as GameObject;
            ParticleSystem.MainModule settings = burstParticle.GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(tex.GetPixels32()[Random.Range(0,tex.GetPixels32().Length)]);
            Destroy(gameObject);
        }
    }
}
