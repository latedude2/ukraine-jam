using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShellDamage : MonoBehaviour
{
    [SerializeField] SpriteRenderer topDamage;
    [SerializeField] SpriteRenderer bottomRightDamage;
    [SerializeField] SpriteRenderer bottomLeftDamage;
    [SerializeField] SpriteRenderer topLeftDamage;
    [SerializeField] SpriteRenderer topRightDamage;

    EggStats eggStats;

    void Start(){
        eggStats = GetComponent<EggStats>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if(eggStats.currentHealthTop < 50){
            topDamage.enabled = true;
        }
        else{
            topDamage.enabled = false;
        }
        if(eggStats.currentHealthBottomRight < 50){
            bottomRightDamage.enabled = true;
        }
        else{
            bottomRightDamage.enabled = false;
        }
        if(eggStats.currentHealthBottomLeft < 50){
            bottomLeftDamage.enabled = true;
        }
        else{
            bottomLeftDamage.enabled = false;
        }
        if(eggStats.currentHealthTopLeft < 50){
            topLeftDamage.enabled = true;
        }
        else{
            topLeftDamage.enabled = false;
        }
        if(eggStats.currentHealthTopRight < 50){
            topRightDamage.enabled = true;
        }
        else{
            topRightDamage.enabled = false;
        }
    }
}
