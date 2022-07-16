using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMainMenu", 5);
    }

    void LoadMainMenu()
    {
        GameObject playerStats = GameObject.Find("PlayerStats");
        if(playerStats != null) playerStats.GetComponent<Progression>().Level = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
