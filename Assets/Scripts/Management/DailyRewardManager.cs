using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardManager : MonoBehaviour
{
    [SerializeField] int playerXP;
    [SerializeField] int playerLevel;
    [SerializeField] int xpForLevelUp = 50;
    [SerializeField] int playerXPPerDay = 10;
    [SerializeField] GameObject RewardEgg;
    [SerializeField] Transform spawnEggTransform;

    [SerializeField] private SerializableList<int> completedDays;
    // Start is called before the first frame update
    void Start()
    {
        completedDays = new SerializableList<int>();
        LoadDataFromPlayerPrefs();
        GiveReward();
    }

    void GiveReward()
    {
        int currentDay = System.DateTime.Now.Day;
        currentDay += System.DateTime.Now.Month * 12;
        currentDay += System.DateTime.Now.Year * 365;
        Debug.Log("Current day: " + currentDay);
        if(completedDays == null)
        {
            completedDays = new SerializableList<int>();
        }
        if (completedDays.list.Contains(currentDay))
        {
            //do nothing
            //Show that the player has already collected the reward
        }
        else
        {
            completedDays.list.Add(currentDay);
            GivePlayerXP();
            StartCoroutine(SpawnRewardEggs());
        }
        SaveDataToPlayerPrefs();
    }


    IEnumerator SpawnRewardEggs()
    {
        for(int i = 0; i < playerXPPerDay; i++)
        {
            Instantiate(RewardEgg, spawnEggTransform);
            //play sound
            //particle effect

            yield return new WaitForSeconds(0.5f);
        }
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
        Debug.Log(PlayerPrefs.GetString("CompletedDays"));
        completedDays = JsonUtility.FromJson<SerializableList<int>>(PlayerPrefs.GetString("CompletedDays"));
        Debug.Log(completedDays);
    }

    void SaveDataToPlayerPrefs()
    {
        PlayerPrefs.SetInt("PlayerXP", playerXP);
        PlayerPrefs.SetInt("PlayerLevel", playerLevel);
        string json = JsonUtility.ToJson(completedDays);
        Debug.Log(json);
        PlayerPrefs.SetString("CompletedDays", json);
    }
}

 [System.Serializable]
 public class SerializableList<T> {
     public List<T> list;

    public SerializableList() {
        list = new List<T>();
    }
 }
