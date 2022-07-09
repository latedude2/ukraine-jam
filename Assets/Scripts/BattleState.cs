using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleState : MonoBehaviour
{
    // Start is called before the first frame update
    EggStats player;
    EggStats enemy;

    // Update is called once per frame
    void Update()
    {
        //if any of player health is 0, then enemy wins
        if(player.currentHealthBottomLeft < 0)
        {
            LoadLoseScene();
        }
        if(enemy.currentHealthBottomLeft < 0)
        {
            LoadUpgradeScene();
        }
        if(player.currentHealthBottomRight < 0)
        {
            LoadLoseScene();
        }
        if(enemy.currentHealthBottomRight < 0)
        {
            LoadUpgradeScene();
        }
        if(player.currentHealthTopLeft < 0)
        {
            LoadLoseScene();
        }
        if(enemy.currentHealthTopLeft < 0)
        {
            LoadUpgradeScene();
        }
        if(player.currentHealthTopRight < 0)
        {
            LoadLoseScene();
        }
        if(enemy.currentHealthTopRight < 0)
        {
            LoadUpgradeScene();
        }
        if(player.currentHealthTop < 0)
        {
            LoadLoseScene();
        }
        if(enemy.currentHealthTop < 0)
        {
            LoadUpgradeScene();
        }
    }

    void LoadLoseScene()
    {
        SceneManager.LoadScene("Lose");
    }

    void LoadUpgradeScene()
    {
        SceneManager.LoadScene("UpgradeEgg");
    }
}
