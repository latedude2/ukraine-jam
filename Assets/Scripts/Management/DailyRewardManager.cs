using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardManager : MonoBehaviour
{
    [SerializeField] int playerXP;
    [SerializeField] int playerLevel;
    [SerializeField] int xpForLevelUp = 10;
    [SerializeField] int playerXPPerDay = 2;
    List<int> completedDays = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        completedDays = new List<int>();
        LoadDataFromPlayerPrefs();
        GiveReward();
    }

    void GiveReward()
    {
        int currentDay = System.DateTime.Now.DayOfYear;
        if (completedDays.Contains(currentDay))
        {
            //do nothing
            //Show that the player has already collected the reward
        }
        else
        {
            completedDays.Add(currentDay);
            GivePlayerXP();

        }
        SaveDataToPlayerPrefs();
    }

    void GivePlayerXP()
    {
        playerXP += playerXPPerDay;
        if (playerXP >= xpForLevelUp)
        {
            playerLevel++;
            playerXP = 0;
        }
    }

    void LevelUpVisuals()
    {
        //Show level up animation
        //Show level up text
        //Unlock new egg
    }

    void LoadDataFromPlayerPrefs()
    {
        playerXP = PlayerPrefs.GetInt("PlayerXP");
        playerLevel = PlayerPrefs.GetInt("PlayerLevel");
        completedDays = JsonUtility.FromJson<List<int>>(PlayerPrefs.GetString("CompletedDays", "[0]"));
    }

    void SaveDataToPlayerPrefs()
    {
        PlayerPrefs.SetInt("PlayerXP", playerXP);
        PlayerPrefs.SetInt("PlayerLevel", playerLevel);
        string json = JsonUtility.ToJson(completedDays);
        PlayerPrefs.SetString("CompletedDays", json);
    }
}
