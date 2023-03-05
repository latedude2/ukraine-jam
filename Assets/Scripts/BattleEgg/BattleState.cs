using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleState : MonoBehaviour
{
    // Start is called before the first frame update
    EggStats player;
    EggStats enemy;
    Progression progression;
    private float fixedDeltaTime;
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Start()
    {
        progression = GameObject.Find("PlayerStats").GetComponent<Progression>();
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
            StartCoroutine(LoadNextScene());
        }
        //-----------------------------
        //if any of player health is 0, then enemy wins
        if(player.currentHealthBottomLeft < 0)
        {
            StartCoroutine(LoadLoseScene());
        }
        if(enemy.currentHealthBottomLeft < 0)
        {
            StartCoroutine(LoadNextScene());
        }
        if(player.currentHealthBottomRight < 0)
        {
            StartCoroutine(LoadLoseScene());
        }
        if(enemy.currentHealthBottomRight < 0)
        {
            StartCoroutine(LoadNextScene());
        }
        if(player.currentHealthTopLeft < 0)
        {
            StartCoroutine(LoadLoseScene());
        }
        if(enemy.currentHealthTopLeft < 0)
        {
            StartCoroutine(LoadNextScene());
        }
        if(player.currentHealthTopRight < 0)
        {
            StartCoroutine(LoadLoseScene());
        }
        if(enemy.currentHealthTopRight < 0)
        {
            StartCoroutine(LoadNextScene());
        }
        if(player.currentHealthTop < 0)
        {
            StartCoroutine(LoadLoseScene());
        }
        if(enemy.currentHealthTop < 0)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadLoseScene()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        SceneManager.LoadScene("Lose");
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        progression.IncreaseLevel();
        if(GameObject.Find("GameModeManager").GetComponent<GameModeManager>().isDailyChallenge)
        {
            SceneManager.LoadScene("DailyReward");
        }
        else if (!GameObject.Find("GameModeManager").GetComponent<GameModeManager>().isStoryMode)
        {
            SceneManager.LoadScene("UpgradeEgg");
        }
        else 
        {
            SceneManager.LoadScene("Victory " + progression.Level);
        }
    }
}
