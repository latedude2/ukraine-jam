using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleState : MonoBehaviour
{
    // Start is called before the first frame update
    EggStats player;
    EggStats enemy;
    private float fixedDeltaTime;
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Start()
    {
        player = GameObject.Find("Egg - Player").GetComponent<EggStats>();
        enemy = GameObject.Find("Egg - Enemy").GetComponent<EggStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //Cheat, remove for launch
        //-----------------------------
        if(Input.GetKeyDown("p") && Input.GetKey("left shift"))
        {
            SceneManager.LoadScene("UpgradeEgg");
        }
        //-----------------------------
        //if any of player health is 0, then enemy wins
        if(player.currentHealthBottomLeft < 0)
        {
            StartCoroutine(LoadLoseScene());
        }
        if(enemy.currentHealthBottomLeft < 0)
        {
            StartCoroutine(LoadUpgradeScene());
        }
        if(player.currentHealthBottomRight < 0)
        {
            StartCoroutine(LoadLoseScene());
        }
        if(enemy.currentHealthBottomRight < 0)
        {
            StartCoroutine(LoadUpgradeScene());
        }
        if(player.currentHealthTopLeft < 0)
        {
            StartCoroutine(LoadLoseScene());
        }
        if(enemy.currentHealthTopLeft < 0)
        {
            StartCoroutine(LoadUpgradeScene());
        }
        if(player.currentHealthTopRight < 0)
        {
            StartCoroutine(LoadLoseScene());
        }
        if(enemy.currentHealthTopRight < 0)
        {
            StartCoroutine(LoadUpgradeScene());
        }
        if(player.currentHealthTop < 0)
        {
            StartCoroutine(LoadLoseScene());
        }
        if(enemy.currentHealthTop < 0)
        {
            StartCoroutine(LoadUpgradeScene());
        }
    }

    IEnumerator LoadLoseScene()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Lose");
    }

    IEnumerator LoadUpgradeScene()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("UpgradeEgg");
    }
}
