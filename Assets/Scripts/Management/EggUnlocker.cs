using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggUnlocker : MonoBehaviour
{
    [SerializeField] int playerLevel;
    [SerializeField] int unlockLevel;
    [SerializeField] Sprite unlockSkin;

    void Start()
    {
        playerLevel = PlayerPrefs.GetInt("PlayerLevel");

        if (playerLevel >= unlockLevel) {
            gameObject.GetComponent<SpriteRenderer>().sprite = unlockSkin;
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

}
