using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public bool isStoryMode = false;
    public bool isDailyChallenge = false;
    void Start()
    {
        //implement singleton
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetModeToStory(bool story)
    {
        isStoryMode = story;
    }

    public void SetModeToDaily(bool daily)
    {
        isDailyChallenge = daily;
    }
}
